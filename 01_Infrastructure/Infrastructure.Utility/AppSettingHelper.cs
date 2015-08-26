using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace Infrastructure.Utility
{
    public class AppSettingHelper
    {
        private static NameValueCollection appSettings;
        static AppSettingHelper()
        {
            appSettings = ConfigurationManager.AppSettings;
        }

        #region GetString

        public static String GetString(String key) {
            return getValue(key, true, null);
        }

        public static String GetString(String key, String defaultValue) {
            return getValue(key, false, defaultValue);
        }

        #endregion

        #region GetStringArray

        public static String[] GetStringArray(String key, String separator) {
            return GetStringArray(key, separator, true, null);
        }

        public static String[] GetStringArray(String key, String separator, String[] defaultValue) {
            return GetStringArray(key, separator, false, defaultValue);
        }

        private static String[] GetStringArray(String key, String separator,Boolean valueRequired, String[] defaultValue) {
            String value = getValue(key, valueRequired, null);
            if (value == null)
                return defaultValue;

            return value.Split(new String[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region GetInt32

        public static Int32 GetInt32(String key) {
            return getInt32(key, null);
        }

        public static Int32 GetInt32(String key, Int32 defaultValue) {
            return getInt32(key, defaultValue);
        }

        private static Int32 getInt32(String key, Int32? defaultValue) {
            return getValue<Int32>(key, (v, pv) => Int32.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region GetBoolean

        public static Boolean GetBoolean(String key) {
            return getBoolean(key, null);

        }

        public static Boolean GetBoolean(String key, Boolean defaultValue) { 
            return getBoolean(key,defaultValue);
        }

        private static Boolean getBoolean(String key,Boolean? defaultValue){
            return getValue<Boolean>(key, (v, pv) => Boolean.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region GetTimeSpan

        public static TimeSpan GetTimeSpan(String key) {
            return TimeSpan.Parse(getValue(key, true, null));
        }

        public static TimeSpan GetTimeSpan(String key, TimeSpan defaultValue) {
            String value = getValue(key, false, null);
            if (!String.IsNullOrEmpty(value))
                return TimeSpan.Parse(value);

            return defaultValue;
        }

        #endregion

        #region PrivateMethods

        private static T getValue<T>(String key,Func<String,T ,Boolean> parseFun, T? defaultValue) where T:struct
        {
            String value = appSettings[key];
            if (!String.IsNullOrEmpty(value))
            { 
                T parseValue = default(T);
                if (parseFun(value, parseValue))
                    return parseValue;
                else
                    throw new ApplicationException(string.Format("Setting '{0}' was not a valid {1}", key, typeof(T).FullName));
            }

            if (!defaultValue.HasValue)
                throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点，且没有指定默认值");
            else
                return defaultValue.Value;
                    
        }

        private static String getValue(String key,Boolean valueRequired,String defaultValue){
            String value=appSettings[key];
            if (null != value)
                return value;

            if (!valueRequired)
                return defaultValue;

            throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点");
        }

        #endregion
    }
}
