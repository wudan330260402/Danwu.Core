using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Config
{
    public static class AppConfig
    {
        
        public static String GetValue(string configKey)
        {
            return ConfigurationManager.AppSettings[configKey].ToString();
        }

    }
}
