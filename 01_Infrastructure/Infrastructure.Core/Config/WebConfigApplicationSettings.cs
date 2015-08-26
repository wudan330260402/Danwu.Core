using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Infrastructure.Core.Config
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {

        public string LoggerName
        {
            get
            {
                return ConfigurationManager.AppSettings["LoggerName"] ?? "";
            }
        }


        string IApplicationSettings.LoggerName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
