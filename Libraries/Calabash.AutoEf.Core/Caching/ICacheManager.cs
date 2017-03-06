using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calabash.AutoEf.Core.Caching
{
    public interface ICacheManager:IDisposable
    {
        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 添加一个键值对缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 获取键对应的值是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsSet(string key);

        /// <summary>
        /// 移除键值对缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清空所有的缓存数据
        /// </summary>
        void Clear();
    }
}
