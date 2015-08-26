using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using Infrastructure.Core.DomainModel;

namespace Infrastructure.Core.Extension
{

    public static class DataRowExtension
    {

        /// <summary>
        /// 将DataRow转换为实体
        /// </summary>
        public static T ConvertToEntity<T>(this DataRow row) where T :class, IAggregateRoot
        {
            Type type = typeof(T);
            //从程序集创建一个实例
            T obj = Assembly.GetAssembly(type).CreateInstance(type.FullName) as T;
            PropertyInfo[] propertiers = type.GetProperties();
            foreach (PropertyInfo p in propertiers) {
                if (null != row[p.Name]){
                    if (row[p.Name] == DBNull.Value)
                    {
                        if (p.PropertyType.ToString() == "System.Int32")
                            p.SetValue(obj, 0, null);
                        else if (p.PropertyType.ToString() == "System.Int64")
                            p.SetValue(obj, 0, null);
                        else if (p.PropertyType.ToString() == "System.Int16")
                            p.SetValue(obj, 0, null);
                        else if (p.PropertyType.ToString() == "System.Decimal")
                            p.SetValue(obj, 0, null);
                        else if (p.PropertyType.ToString() == "System.Double")
                            p.SetValue(obj, 0.0, null);
                        else if (p.PropertyType.ToString() == "System.DateTime")
                            p.SetValue(obj, Convert.ToDateTime("0001-01-01"), null);
                        else if (p.PropertyType.ToString() == "System.Boolean")
                            p.SetValue(obj, true, null);
                        else if (p.PropertyType.ToString() == "System.String")
                            p.SetValue(obj, "", null);
                        else
                            p.SetValue(obj, "", null);
                    }
                    else
                    {
                        if (p.PropertyType.ToString() == "System.Int32")
                            p.SetValue(obj, Convert.ToInt32(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.Int64")
                            p.SetValue(obj, Convert.ToInt64(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.Int16")
                            p.SetValue(obj, Convert.ToInt16(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.Decimal")
                            p.SetValue(obj, Convert.ToDecimal(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.Double")
                            p.SetValue(obj, Convert.ToDouble(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.DateTime")
                            p.SetValue(obj, Convert.ToDateTime(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.Boolean")
                            p.SetValue(obj, Convert.ToBoolean(row[p.Name]), null);
                        else if (p.PropertyType.ToString() == "System.String")
                            p.SetValue(obj, row[p.Name].ToString(), null);
                        else
                            p.SetValue(obj, row[p.Name], null);
                    }
                }
            }

            return obj;
        }

    }

}
