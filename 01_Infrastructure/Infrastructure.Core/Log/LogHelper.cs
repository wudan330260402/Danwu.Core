using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Log
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 获取日志一个实例
        /// </summary>
        private static ILogger logInstance = LoggerFactory.GetLogInstance();

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public static void WriteInfo(String title, String message) {
            logInstance.WriteInfo(title, message);
        }

        /// <summary>
        /// 记录Debug信息
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public static void WriteDebug(String title, String message) {
            logInstance.WriteDebug(title, message);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public static void WriteError(String title, String message) {
            logInstance.WriteError(title, message);
        }
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="title"></param>
        /// <param name="ex"></param>
        public static void WriteException(String title, Exception ex) {
            logInstance.WriteException(title, ex);
        }
    }
}
