using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

namespace Infrastructure.Core.Repository
{
    /// <summary>
    /// windows程序session管理
    /// </summary>
    public class ThreadSessionStorage : ISessionStorage
    {
        [ThreadStatic]
        private static ISession _session;

        /// <summary>
        /// 获得ISession
        /// </summary>
        /// <returns></returns>
        public ISession Get()
        {
            if (_session != null) {
                if (!_session.IsConnected) {
                    _session.Reconnect();
                }
            }

            return _session;
        }

        /// <summary>
        /// 保存ISession
        /// </summary>
        /// <param name="value"></param>
        public void Set(ISession value)
        {
            if (value.IsConnected) {
                value.Disconnect();
            }

            _session = value;
        }
    }
}
