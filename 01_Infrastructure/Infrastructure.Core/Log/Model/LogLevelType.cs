using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Log.Model
{
    /// <summary>
    /// 日志级别分类
    /// </summary>
    internal enum LogLevelType
    {
        Info,
        Debug,
        Event,
        Error,
        Exception
    }
}
