using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using NHibernate;

namespace Infrastructure.Core.Repository
{
    /// <summary>
    /// http程序的session管理
    /// </summary>
    public class HttpSessionStorage : ISessionStorage
    {
        /// <summary>
        /// 获得ISession
        /// </summary>
        /// <returns></returns>
        public NHibernate.ISession Get()
        {
            if (HttpContext.Current.Items["SessionNhb"] != null)
                return (ISession)HttpContext.Current.Items["SessionNhb"];

            return null;
        }

        /// <summary>
        /// 保存ISession
        /// </summary>
        /// <param name="value"></param>
        public void Set(NHibernate.ISession value)
        {
            if (value != null)
                HttpContext.Current.Items["SessionNhb"] = value;
        }
    }
}
