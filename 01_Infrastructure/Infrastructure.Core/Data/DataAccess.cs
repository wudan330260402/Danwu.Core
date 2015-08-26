
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Infrastructure.Core.Data.Base;
using Infrastructure.Core.Config;

namespace Infrastructure.Core.Data
{
    public sealed class DataAccess
    {
        private static readonly string path = AppConfig.GetValue("AssemblyPath");
        private static readonly string assemblyName = AppConfig.GetValue("DBType") + "Helper";

        public static BaseHelper CreateDBHelper()
        {
            return (BaseHelper)Assembly.Load(path).CreateInstance(path + "." + assemblyName);
        }

        public static BaseHelper CreateDBHelper(String connStr)
        {
            return (BaseHelper)Assembly.Load(path).CreateInstance(path + "." + assemblyName, true, BindingFlags.CreateInstance, null, new object[] { connStr }, null, null);
        }

        public static BaseHelper CreateDBHelper(ConnectionType connType, String connStr)
        {
            return (BaseHelper)Assembly.Load(path).CreateInstance(path + "." + assemblyName, true, BindingFlags.CreateInstance, null, new object[] { connType, connStr }, null, null);
        }

    }
}
