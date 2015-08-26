using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.IOC
{
    /// <summary>
    /// 服务获取接口
    /// </summary>
    public interface IServiceLocator
    {
        TService Resolve<TService>() where TService : class;
        TService Resolve<TService>(String name) where TService : class;

        Object Resolve(Type serviceType);
        Object Resolve(Type serviceType, String name);
    }
}
