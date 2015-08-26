using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using log4net;

namespace Infrastructure.Core.Log
{
    internal class Log4Net : ILogger
    {
        private ILog _log;

        public Log4Net() {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void WriteInfo(string title, string message)
        {
            _log.Info(String.Format("Title:{0},Message:{1}", title, message));
        }

        public void WriteDebug(string title, string message)
        {
            throw new NotImplementedException();
        }

        public void WriteError(string title, string message)
        {
            _log.Error(String.Format("Title:{0},Message:{1}", title, message));
        }

        public void WriteException(string title, Exception ex)
        {
            _log.Error(String.Format("Title:{0},Message:{1}", title, ex.Message), ex);
        }
        
    }
}
