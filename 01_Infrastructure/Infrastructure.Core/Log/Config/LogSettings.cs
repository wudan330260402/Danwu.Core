using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Log.Config
{
    /// <summary>
    /// 日志配置
    /// </summary>
    internal class LogSettings : ConfigurationSection
    {
        /// <summary>
        /// 是否启用日志
        /// </summary>
        public bool IsEnabled {
            get { return (bool)base["IsEnabled"]; }
            set { base["IsEnabled"] = value; }
        }
    }
}
