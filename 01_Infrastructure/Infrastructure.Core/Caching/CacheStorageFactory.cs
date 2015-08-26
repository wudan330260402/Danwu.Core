using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Caching
{
    internal static class CacheStorageFactory
    {
        private static ICacheStorage _cacheStorage;
        private static String _cacheMode = System.Configuration.ConfigurationManager.AppSettings["CacheMode"] ?? "DefaultCache";        

        public static ICacheStorage CacheStorageInstance {
            get {
                switch (_cacheMode) {
                    case "DefaultCache":
                        _cacheStorage = new DefaultCacheStorage();
                        break;
                    case "MemcacheMode":
                        _cacheStorage = new MemcacheStorage();
                        break;
                    case "LocalCache":
                        _cacheStorage = new LocalCacheStorage();
                        break;
                    default:
                        _cacheStorage = new DefaultCacheStorage();
                        break;
                }
                return _cacheStorage;
            }
        }

    }
}
