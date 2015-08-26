using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Infrastructure.Core.Caching
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        private static ICacheStorage cacheInstance = CacheStorageFactory.CacheStorageInstance;

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public static void Add(String key, Object obj) {
            cacheInstance.Add(key, obj);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean IsExist(String key)
        {
            return cacheInstance.IsExist(key);
        }
        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Object Get(String key)
        {
            return cacheInstance.Get(key);
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(String key)
        {
            cacheInstance.Remove(key);
        }
    }
}
