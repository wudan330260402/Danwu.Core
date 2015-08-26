using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.ServiceProxy
{
    public class ServiceProxyFactory
    {
        private readonly static ConcurrentDictionary<Type, Func<Object>> _creatorCache = new ConcurrentDictionary<Type, Func<object>>();

        public static TChannel CreateChannel<TChannel>() where TChannel : class {
            return (TChannel)new ServiceProxy<TChannel>().GetTransparentProxy();
        }
    }
}
