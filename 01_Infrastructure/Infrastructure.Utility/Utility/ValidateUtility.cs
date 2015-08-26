using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Utility.Utility
{
    /// <summary>
    /// 校验类
    /// </summary>
    public class ValidateUtility
    {
        /// <summary>
        /// 手机验证
        /// </summary>
        public static Boolean Validate_Mobile(String mobileNum) {
            if (String.IsNullOrEmpty(mobileNum))
                return false;
            return ValidateByRegular(mobileNum, "");
        }
        public static Boolean Validate_Mobile(String mobileNum, String pattern) {
            if (String.IsNullOrEmpty(mobileNum) || String.IsNullOrEmpty(pattern))
                return false;

            return ValidateByRegular(mobileNum, pattern);
        }

        /// <summary>
        /// 邮箱验证
        /// </summary>
        public static Boolean Validate_Email(String email) {
            if (String.IsNullOrEmpty(email))
                return false;

            return ValidateByRegular(email, "");
        }
        public static Boolean Validate_Email(String email,String pattern) {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(pattern))
                return false;

            return ValidateByRegular(email, pattern);
        }

        /// <summary>
        /// IP验证
        /// </summary>
        public static Boolean Validate_IP(String ip) {
            if (String.IsNullOrEmpty(ip))
                return false;

            return ValidateByRegular(ip, "");
        }
        public static Boolean Validate_IP(String ip, String pattern)
        {
            if (String.IsNullOrEmpty(ip) || String.IsNullOrEmpty(pattern))
                return false;

            return ValidateByRegular(ip, pattern);
        }


        /// <summary>
        /// 正则验证
        /// </summary>
        public static Boolean ValidateByRegular(String source, String pattern) {
            if (String.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source, pattern);
        }
    }
}
