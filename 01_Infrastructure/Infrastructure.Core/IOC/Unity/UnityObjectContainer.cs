using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Infrastructure.Core.IOC
{
    public class UnityObjectContainer : ObjectContainer
    {
        private IUnityContainer _container = null;

        public UnityObjectContainer() {
            _container = new UnityContainer();
        }

        public override void RegisterService(Type from, Type to, LifeStyle lifeStyle)
        {
            switch (lifeStyle) { 
                case LifeStyle.Transient:
                    _container.RegisterType(from, to, new TransientLifetimeManager());
                    break;
                case LifeStyle.Singleton:
                    _container.RegisterType(from, to, new ContainerControlledLifetimeManager());
                    break;
            }
        }
        public override void RegisterService(Type from, Type to, string serviceName, LifeStyle lifeStyle)
        {
            switch (lifeStyle)
            {
                case LifeStyle.Transient:
                    _container.RegisterType(from, to, serviceName, new TransientLifetimeManager());
                    break;
                case LifeStyle.Singleton:
                    _container.RegisterType(from, to, serviceName, new ContainerControlledLifetimeManager());
                    break;
            }
        }

        public override TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }
        public override TService Resolve<TService>(string name)
        {
            return _container.Resolve<TService>(name);
        }

        public override object Resolve(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }
        public override object Resolve(Type serviceType, string name)
        {
            return _container.Resolve(serviceType, name);
        }
    }
}
