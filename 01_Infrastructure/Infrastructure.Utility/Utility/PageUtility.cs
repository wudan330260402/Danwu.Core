using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Infrastructure.Utility.Utility
{
    public static class PageUtility
    {
        #region Cookie

        /// <summary>
        /// 获取Cookie值
        /// </summary>
        public static String GetCookie(String cookieName) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
                return "";

            return cookie.Value;
        }

        /// <summary>
        /// 设置Cookie的值
        /// </summary>
        public static void SetCookie(String cookieName, String cookieValue) {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
            if (cookie != null)
                HttpContext.Current.Response.Cookies.Remove(cookieName);

            cookie = new HttpCookie(cookieName, cookieValue);
            SetCookie(cookie);
        }
        public static void SetCookie(String cookieName, String cookieValue, DateTime expires) {
            HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
            if (cookie != null)
                HttpContext.Current.Response.Cookies.Remove(cookieName);

            cookie = new HttpCookie(cookieName, cookieValue);
            cookie.Expires = expires;
            SetCookie(cookie);
        }
        public static void SetCookie(HttpCookie cookie) {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null) {
                cookie.HttpOnly = true;
                cookie.Path = "/";
                //追加cookie
                response.AppendCookie(cookie);
            }
        }

        /// <summary>
        /// 置过期
        /// </summary>
        public static void ExpiredCookie(String cookieName) {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
                cookie.Expires = DateTime.Now.AddDays(-1);
        }

        #endregion

        #region Session

        public static Object GetSession(String sessionName) {
            return HttpContext.Current.Session[sessionName];            
        }

        public static void SetSession(String sessionName, Object Value) {
            if (HttpContext.Current.Session[sessionName] != null)
                HttpContext.Current.Session[sessionName] = null;

            HttpContext.Current.Session[sessionName] = Value;
        }

        #endregion
    }
}
