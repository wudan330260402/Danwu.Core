using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Caching
{
    internal class RedisStorage : ICacheStorage
    {
        public RedisStorage() { 
            
        }

        public void Add(string key, object obj)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string key)
        {
            throw new NotImplementedException();
        }

        public object Get(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public string RegionName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
