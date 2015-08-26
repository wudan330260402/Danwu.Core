using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Infrastructure.Core.IOC
{
    /// <summary>
    /// 服务定位器
    /// </summary>
    public class ServiceLocator : IServiceProvider
    {
        private IUnityContainer container;

        private static ServiceLocator instance = new ServiceLocator();

        private ServiceLocator() {
            InitIocContainer();
        }

        /// <summary>
        /// 初始化UnitContainer
        /// </summary>
        void InitIocContainer() {

            UnityConfigurationSection section = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
            if (section == null) {
                var rootPath = AppDomain.CurrentDomain.BaseDirectory;
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
                {
                    ExeConfigFilename = String.Format("{0}/unity.config", rootPath)
                };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                section = (UnityConfigurationSection)config.GetSection(UnityConfigurationSection.SectionName);
            }
            container = new UnityContainer();
            section.Configure(container, UnityConfigurationSection.SectionName);

        }

        /// <summary>
        /// 对象实例
        /// </summary>
        public static ServiceLocator Instance {
            get {
                return instance;
            }
        }

        #region Public Methods

        public T Resolve<T>() {
            return container.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>() {
            return container.ResolveAll<T>();
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
