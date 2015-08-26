using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Extension
{
    /// <summary>
    /// 可空类型安全取值扩展
    /// </summary>
    public static class NullableExtension
    {
        /// <summary>
        /// 安全获取值
        /// 例如：int?,DateTime?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value.HasValue ? value.Value : default(T);
        }

        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Boolean IsNullOrEmpty(this Object obj) {
            if (obj == null) return true;
            if (obj.GetType().IsValueType) return false;
            if (obj.GetType() == typeof(System.String)) return obj == String.Empty;
            return false;
        }
    }

}
