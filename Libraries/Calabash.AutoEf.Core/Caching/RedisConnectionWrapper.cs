using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Calabash.AutoEf.Core.Configuration;
using StackExchange.Redis;

namespace Calabash.AutoEf.Core.Caching
{
    public class RedisConnectionWrapper:IRedisConnectionWrapper
    {
        /// <summary>
        /// 获取redis配置信息
        /// </summary>
        private readonly CalabashConfig _config;
        /// <summary>
        /// 懒加载连接字符串
        /// </summary>
        private readonly Lazy<string> _connectionString;
        /// <summary>
        /// ConnectionMultiplexer 应该被多任务状态下共享
        /// </summary>
        private volatile ConnectionMultiplexer _connection;

        private readonly object _lock=new object();


        public RedisConnectionWrapper(CalabashConfig config)
        {
            this._config = config;
            this._connectionString=new Lazy<string>(GetConnectionString);
        }


        private string GetConnectionString()
        {
            return _config.RedisCachingConnectionString;
        }

        private ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected) return _connection;
            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected) return _connection;
                if (_connection != null)
                {
                    //没有连接上释放出去
                    _connection.Dispose();
                }
                //重新连接新的redis
                _connection=ConnectionMultiplexer.Connect(_connectionString.Value);
            }
            return _connection;
        }

        public IDatabase Database(int? db = null)
        {
            return GetConnection().GetDatabase(db ?? -1);
        }

        public IServer Server(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        public void FlushDb(int? db = null)
        {
            var endPoints = GetEndPoints();
            foreach (var endPoint in endPoints)
            {
                Server(endPoint).FlushDatabase(db??-1);
            }
        }
        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
    }
}
