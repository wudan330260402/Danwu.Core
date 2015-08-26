using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.IOC
{
    /// <summary>
    /// 服务注册接口
    /// </summary>
    public interface IServiceRegister
    {
        void RegisterService<TFrom, TTo>();
        void RegisterService<TFrom, TTo>(String serviceName);
        void RegisterService<TFrom, TTo>(LifeStyle lifeStyle);
        void RegisterService<TFrom, TTo>(String serviceName, LifeStyle lifeStyle);

        void RegisterService(Type from, Type to);
        void RegisterService(Type from, Type to, String serviceName);
        void RegisterService(Type from, Type to, LifeStyle lifeStyle);
        void RegisterService(Type from, Type to, String serviceName, LifeStyle lifeStyle);
    }
}
