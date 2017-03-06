using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calabash.AutoEf.Core.Configuration;
using Calabash.AutoEf.Core.Infrastructure;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Calabash.AutoEf.Core.Caching
{
    public partial class RedisCacheManager:ICacheManager
    {
        #region Fileds

        private readonly IRedisConnectionWrapper _connectionWrapper;
        private readonly IDatabase _db;
        private readonly ICacheManager _perRequestCacheManager;
        #endregion

        #region Ctor

        public RedisCacheManager(CalabashConfig config, IRedisConnectionWrapper connectionWrapper)
        {
            if(String.IsNullOrEmpty(config.RedisCachingConnectionString))
                throw new Exception("Redis connection string is empty");
            this._connectionWrapper = connectionWrapper;
            this._db = _connectionWrapper.Database();
            this._perRequestCacheManager = EngineContext.Current.Resolve<ICacheManager>();
        }

        #endregion

        #region Utilities
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serializedObject"></param>
        /// <returns></returns>
        protected virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);
            var jsonString = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }


        #endregion

        #region Methods
        public T Get<T>(string key)
        {
            if (_perRequestCacheManager.IsSet(key))
                return _perRequestCacheManager.Get<T>(key);

            var rValue = _db.StringGet(key);
            if (!rValue.HasValue)
                return default(T);
            var result = Deserialize<T>(rValue);
            _perRequestCacheManager.Set(key,result,0);
            return result;
        }

        public void Set(string key, object data, int cacheTime)
        {
            if(data==null)
                return;
            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);
            _db.StringSet(key, entryBytes, expiresIn);
        }

        public bool IsSet(string key)
        {
            if (_perRequestCacheManager.IsSet(key))
                return true;
            return _db.KeyExists(key);
        }

        public void Remove(string key)
        {
            _db.KeyDelete(key);
            _perRequestCacheManager.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.Server(ep);
                var keys = server.Keys(pattern: "*" + pattern + "*");
                foreach (var key in keys)
                {
                    _db.KeyDelete(key);
                }
            }
        }

        public void Clear()
        {
            foreach (var key in _connectionWrapper.GetEndPoints().Select(ep => _connectionWrapper.Server(ep)).Select(server => server.Keys()).SelectMany(keys => keys))
            {
                _db.KeyDelete(key);
            }
        }

        public void Dispose()
        {
        }


        #endregion
    }
}
