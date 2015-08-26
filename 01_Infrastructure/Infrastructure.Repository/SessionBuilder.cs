using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

using Infrastructure.Core.Repository;

namespace Infrastructure.Repository.NHibernate
{
    public class SessionBuilder
    {
        private static Object obj = new Object();
        private static String cfgPath = AppDomain.CurrentDomain.BaseDirectory + @"hibernate.cfg.xml";
        private static String SessionMode = System.Configuration.ConfigurationManager.AppSettings["SessionMode"] ?? "HttpSession";

        //[ThreadStatic]
        //private static ISession _session;
        private static ISessionFactory _sessionFactory;
        private static Configuration _cfg;
        private static ISessionStorage _sessionStorage;

        static SessionBuilder() {
            //if (SessionMode == "HttpSession") _sessionStorage = new HttpSessionStorage();
            //else _sessionStorage = new ThreadSessionStorage();
            _sessionStorage = SessionStorageFactory.SessionStorageInstance;
        }

        public static ISession SessionInstance {
            //方法一：单例模式获取session
            //get {
            //    if (_session == null) {
            //        lock (obj) {
            //            if (_session == null) {
            //                _session = SessionFactory.OpenSession();
            //            }
            //        }
            //    }
            //    return _session;
            //}

            get {
                ISession s = _sessionStorage.Get();
                if (s == null){
                    lock (obj){
                        if (s == null){
                            s = SessionFactory.OpenSession();
                            _sessionStorage.Set(s);
                        }
                    }
                }
                return s;
            }
        }
        public static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null)
                {
                    lock (obj)
                    {
                        _sessionFactory = Cfg.BuildSessionFactory();
                    }
                }

                return _sessionFactory;
            }
        }
        public static Configuration Cfg {
            get {
                if (_cfg == null)
                {
                    lock (obj){
                        if (_cfg == null)
                        {
                            _cfg = CreateConfiguration();
                        }
                    }
                }
                return _cfg;
            }
        }

        private static Configuration CreateConfiguration()
        {
            //cfg = new Configuration();
            //IDictionary props = new Hashtable();

            //props["hibernate.connection.provider"] = "NHibernate.Connection.DriverConnectionProvider";
            //props["hibernate.dialect"] = "NHibernate.Dialect.MsSql2000Dialect";
            //props["hibernate.connection.driver_class"] = "NHibernate.Driver.SqlClientDriver";
            //props["hibernate.connection.connection_string"] = "Server=.;initial catalog=CIP2;userid=sa;pwd=123456;Integrated Security=SSPI";

            //foreach (DictionaryEntry p in props)
            //{
            //    cfg.SetProperty(p.Key.ToString(), p.Value.ToString());
            //}

            //cfg.AddAssembly("Infrastructure.Models");
            //return cfg;
            return new Configuration().Configure(cfgPath);
        }
    }
}
