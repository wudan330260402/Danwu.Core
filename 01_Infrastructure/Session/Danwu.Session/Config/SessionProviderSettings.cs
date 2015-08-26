using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Danwu.Session
{
    /// <summary>
    /// 自定义SessionProvider配置
    /// </summary>
    class SessionProviderSettings : ConfigurationSection
    {
        SessionProviderSettings() { }

        static SessionProviderSettings _sessionProviderSettings;

        public static SessionProviderSettings GetSettings()
        {
            if (_sessionProviderSettings == null) {
                _sessionProviderSettings = ConfigurationManager.GetSection("SessionProviderSettings") as SessionProviderSettings;
            }
            return _sessionProviderSettings;
        }

        /// <summary>
        /// SessionStateBehavior
        /// </summary>
        [ConfigurationProperty("SessionStateBehavior", IsRequired = false)]
        public String SessionStateBehavior
        {
            get { return (String)base["SessionStateBehavior"]; }
            set { base["SessionStateBehavior"] = value; }
        }

        /// <summary>
        /// SessionId前缀
        /// </summary>
        [ConfigurationProperty("SessionProfix",IsRequired=false)]
        public String SessionProfix {
            get { return (String)base["SessionProfix"]; }
            set { base["SessionProfix"] = value; }
        }

        /// <summary>
        /// 加密Key
        /// </summary>
        [ConfigurationProperty("DesKey",IsRequired=false)]
        public String DesKey {
            get { return (String)base["DesKey"]; }
            set { base["DesKey"] = value; }
        }


    }
}
