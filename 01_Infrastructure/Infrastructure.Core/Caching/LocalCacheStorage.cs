using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Infrastructure.Core.Caching
{
    internal class LocalCacheStorage : ICacheStorage
    {
        private ObjectCache cache;

        #region Ctors

        public LocalCacheStorage()
            : this("")
        {

        }
        public LocalCacheStorage(String regionName) {
            this.RegionName = regionName;
            cache = MemoryCache.Default;
        }

        #endregion

        /// <summary>
        /// 区域
        /// </summary>
        public string RegionName
        {
            get;
            private set;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Add(string key, object obj)
        {
            var cacheItem = new CacheItem(GeneralKey(key), obj);

            var cacheItemPolicy = new CacheItemPolicy();
            cache.Add(cacheItem, cacheItemPolicy);
        }

        /// <summary>
        /// 是否存在键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            return cache.Contains(GeneralKey(key));
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return cache.Get(GeneralKey(key));
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            cache.Remove(GeneralKey(key));
        }

        #region Private Methods

        /// <summary>
        /// 组合key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private String GeneralKey(String key) {

            return String.Format("{0}_{1}", this.RegionName, key);
        }

        #endregion

    }
}
