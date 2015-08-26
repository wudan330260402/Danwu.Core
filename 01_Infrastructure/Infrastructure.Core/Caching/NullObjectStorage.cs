using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Caching
{
    /// <summary>
    /// 空缓存
    /// </summary>
    internal class NullObjectStorage : ICacheStorage
    {

        public NullObjectStorage() { 
            
        }

        public void Add(string key, object obj)
        {
            //Do nothing
        }

        public bool IsExist(string key)
        {
            return false;
        }

        public object Get(string key)
        {
            //Do nothing
            return null;
        }

        public void Remove(string key)
        {
            //Do nothing
        }


        public string RegionName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
