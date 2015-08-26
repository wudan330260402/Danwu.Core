using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Caching
{
    internal interface ICacheStorage
    {
        /// <summary>
        /// 缓存区域名称
        /// </summary>
        string RegionName { get; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        void Add(String key, Object obj);
        /// <summary>
        /// 是否存在键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Boolean IsExist(String key);
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Object Get(String key);
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        void Remove(String key);
    }
}
