using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Threading.Tasks;

namespace Infrastructure.Core.Caching
{
    internal class DefaultCacheStorage : ICacheStorage
    {
        private HttpContext context = null;
        
        public DefaultCacheStorage() {
            context = HttpContext.Current;
        }

        /// <summary>
        /// 区块
        /// </summary>
        public string RegionName { get; private set; }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        public void Add(string key, object obj)
        {
            context.Cache.Insert(key, obj, null, DateTime.Now.AddDays(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 判断键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsExist(string key)
        {
            if (context.Cache[key] != null)
                return true;
            return false;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (context.Cache[key] != null)
                return context.Cache.Get(key);
            return null;
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (context.Cache[key] != null)
                context.Cache.Remove(key);
        }




        
    }
}
