using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using NHibernate;

namespace Infrastructure.Core.Repository
{
    /// <summary>
    /// Session存储器接口
    /// </summary>
    public interface ISessionStorage
    {
        /// <summary>
        /// 获得ISession 
        /// </summary>
        /// <returns></returns>
        ISession Get();

        /// <summary>
        /// 保存ISession
        /// </summary>
        /// <param name="value"></param>
        void Set(ISession value);
    }
}
