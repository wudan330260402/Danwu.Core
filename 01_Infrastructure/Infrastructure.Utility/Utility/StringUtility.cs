using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Utility.Utility
{
    public class StringUtility
    {
        private static String Letters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static String IntLetters = "0123456789";

        /// <summary>
        /// 生成优惠券code
        /// </summary>
        public static String CreateCouponCode(String preStr,Int32 len)
        {
            if (len <= 0)
                throw new Exception("长度len必须大于0");

            char[] array = Letters.ToCharArray();
            StringBuilder couponCode = new StringBuilder();
            couponCode.Append(preStr);

            for (Int32 i = 0; i < len; i++) { 
                Int32 randomIndex = new Random(Guid.NewGuid().GetHashCode()).Next(0, 35);
                couponCode.Append(array[randomIndex]);
            }

            return couponCode.ToString();
        }

        public static String CreateIntCouponCode(String preStr, Int32 len) {
            if (len <= 0)
                throw new Exception("长度len必须大于0");

            char[] array = IntLetters.ToCharArray();
            StringBuilder couponCode = new StringBuilder();
            couponCode.Append(preStr);

            for (Int32 i = 0; i < len; i++)
            {
                Int32 randomIndex = new Random(Guid.NewGuid().GetHashCode()).Next(0, 9);
                couponCode.Append(array[randomIndex]);
            }

            return couponCode.ToString();
        }
    }
}
