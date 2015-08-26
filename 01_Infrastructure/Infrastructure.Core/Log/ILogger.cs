using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Log
{
    internal interface ILogger
    {
        void WriteInfo(String title, String message);

        void WriteDebug(String title, String message);

        void WriteError(String title, String message);

        void WriteException(String title, Exception ex);
    }
}
