using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.IOC
{
    public abstract class ObjectContainer : IObjectContainer
    {

        #region IServiceRegister Members

        public void RegisterService<TFrom, TTo>()
        {
            RegisterService(typeof(TFrom), typeof(TTo));
        }
        public void RegisterService<TFrom, TTo>(string serviceName)
        {
            RegisterService(typeof(TFrom), typeof(TTo), serviceName);
        }
        public void RegisterService<TFrom, TTo>(LifeStyle lifeStyle)
        {
            RegisterService(typeof(TFrom), typeof(TTo), lifeStyle);
        }
        public void RegisterService<TFrom, TTo>(string serviceName, LifeStyle lifeStyle)
        {
            RegisterService(typeof(TFrom), typeof(TTo), serviceName, lifeStyle);
        }
        
        public void RegisterService(Type from, Type to)
        {
            RegisterService(from, to, LifeStyle.Transient);
        }
        public void RegisterService(Type from, Type to, string serviceName)
        {
            RegisterService(from, to, serviceName, LifeStyle.Transient);
        }
        public abstract void RegisterService(Type from, Type to, LifeStyle lifeStyle);
        public abstract void RegisterService(Type from, Type to, string serviceName, LifeStyle lifeStyle);

        #endregion

        #region IServiceLocator Members

        public abstract TService Resolve<TService>() where TService : class;
        public abstract TService Resolve<TService>(string name) where TService : class;
        
        public abstract object Resolve(Type serviceType);
        public abstract object Resolve(Type serviceType, string name);

        #endregion

    }
}
