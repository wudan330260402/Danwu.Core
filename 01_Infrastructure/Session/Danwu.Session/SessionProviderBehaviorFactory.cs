using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.Session
{
    /// <summary>
    /// Session驱动行为工厂
    /// </summary>
    public class SessionProviderBehaviorFactory
    {
        /// <summary>
        /// 当前Session状态存储行为实例
        /// </summary>
        static ISessionStateStoreBehavior sessionStateStoreBehavior;

        /// <summary>
        /// 创建Session状态存储行为实例
        /// </summary>
        /// <returns></returns>
        public static ISessionStateStoreBehavior CreateSessionStateStoreBehaviorInstance() {

            if (sessionStateStoreBehavior == null) {
                var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.GetInterface(typeof(ISessionStateStoreBehavior).Name) != null);
                var currentType = types.FirstOrDefault(t => t.Name == String.Format("{0}SessionStateBehavior", SessionProviderSettings.GetSettings().SessionStateBehavior));
                if (currentType != null) {
                    sessionStateStoreBehavior = (ISessionStateStoreBehavior)Activator.CreateInstance(currentType);
                }
            }
            return sessionStateStoreBehavior;

        }
    }
}
