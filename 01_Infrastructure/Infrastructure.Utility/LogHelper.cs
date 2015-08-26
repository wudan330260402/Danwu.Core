using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Utility
{
    /// <summary>
    /// 日之类
    /// </summary>
    public class LogHelper
    {

        private static String rootPath = AppSettingHelper.GetString("LogRootPath");
        //private static String rootPath = AppDomain.CurrentDomain.BaseDirectory;

        #region 其他

        public static void Write(String methodName, StringBuilder content)
        {
            String filePath = rootPath + @"\Log";
            if (!String.IsNullOrEmpty(methodName))
                filePath += @"\" + methodName;
            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder msg = new StringBuilder();
            msg.Append("**************************************" + methodName + "**************************************\r\n");
            msg.Append(content.ToString());
            msg.Append("\r\n**************************************" + methodName + "**************************************\r\n");

            CommonLog.Instance.SaveToLog(filePath, fileName, msg.ToString());
        }

        public static void Exception(StringBuilder content)
        {
            String filePath = rootPath + @"\Exception";
            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder msg = new StringBuilder();
            msg.Append("**************************************异常信息**************************************\r\n");
            msg.Append(content.ToString());
            msg.Append("\r\n**************************************异常信息**************************************\r\n");

            CommonLog.Instance.SaveToLog(filePath, fileName, msg.ToString());
        }
        public static void Exception(Exception ex, StringBuilder content)
        {
            String filePath = rootPath + @"\Exception";
            String fileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            StringBuilder msg = new StringBuilder();
            msg.Append("**************************************异常信息**************************************\r\n");
            msg.Append(content.ToString());
            msg.Append("\r\n**************************************异常信息**************************************\r\n");

            CommonLog.Instance.SaveToLog(filePath, fileName, msg.ToString());
        }

        #endregion

    }
}
