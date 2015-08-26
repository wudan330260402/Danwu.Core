using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;


namespace Infrastructure.Core.Unity
{
    /// <summary>
    /// Unity容器工厂
    /// </summary>
    public sealed class UnityContainerFactory
    {
        private static IUnityContainer _container = null;
        private static String path = HttpContext.Current.Server.MapPath("~/unity/unity.config");
        private static Object obj = new Object();

        public static IUnityContainer ContainerInstance
        {
            get
            {
                if (null == _container)
                {
                    lock (obj)
                    {
                        if (null == _container)
                        {
                            _container = new UnityContainer();
                            LoadConfig(_container, path);
                        }
                    }
                }
                return _container;
            }
        }

        private static void LoadConfig(IUnityContainer container, String filePath)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap()
            {
                ExeConfigFilename = filePath
            };

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(
                fileMap,
                ConfigurationUserLevel.None);

            UnityConfigurationSection section = (UnityConfigurationSection)config.GetSection("unity");

            if (section.Containers.Default != null)
                section.Containers.Default.Configure(container);
        }
    }
}
