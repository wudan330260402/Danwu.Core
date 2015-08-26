using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Memcached.ClientLibrary;

namespace Infrastructure.Core.Caching
{
    internal class MemcacheStorage : ICacheStorage
    {
        private MemcachedClient client;

        public MemcacheStorage() {
            //分布Memcachedf服务IP 端口
            String[] servers = { "192.168.77.128:11211", "192.168.77.128:11212" };

            //初始化池
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(servers);
            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;
            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;
            pool.MaintenanceSleep = 30;
            pool.Failover = true;
            pool.Nagle = false;
            pool.Initialize();

            //实例化一个client
            client = new MemcachedClient();
            client.EnableCompression = false;
        }

        public void Add(string key, object obj)
        {
            client.Set(key, obj);
        }

        public bool IsExist(string key)
        {
            return client.KeyExists(key);
        }

        public object Get(string key)
        {
            return client.Get(key);
        }

        public void Remove(string key)
        {
            client.Delete(key);
        }

        public string RegionName
        {
            get { throw new NotImplementedException(); }
        }
    }
}
