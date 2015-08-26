using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Exceptions
{
    /// <summary>
    /// 根异常
    /// </summary>
    public class RootException : Exception
    {
        public RootException()
            : base()
        { }

        public RootException(String message)
            : base(message)
        { }

        public RootException(String message, Exception exception)
            : base(message, exception)
        { }
    }
}
