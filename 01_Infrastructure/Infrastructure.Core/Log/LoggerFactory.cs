using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Log
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    internal class LoggerFactory
    {
        private static ILogger _log;
        private static String _logMode = System.Configuration.ConfigurationManager.AppSettings["LogMode"] ?? "Log4Net";

        public static ILogger GetLogInstance() {
            switch (_logMode) { 
                case "log4net":
                    _log = new Log4Net();
                    break;
                case "MongoDB":
                    _log = new MongoLogger();
                    break;
                default:
                    break;
            }
            return _log;
        }
    }
}
