using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Repository
{
    public class SessionStorageFactory
    {
        private static String _sessionMode = System.Configuration.ConfigurationManager.AppSettings["SessionMode"] ?? "HttpSession";        
        private static ISessionStorage _sessionStorage;

        public static ISessionStorage SessionStorageInstance {
            get {
                switch (_sessionMode) {
                    case "HttpSession":
                        _sessionStorage = new HttpSessionStorage();
                        break;
                    case "ThreadSession":
                        _sessionStorage = new ThreadSessionStorage();
                        break;
                    default:
                        _sessionStorage = new HttpSessionStorage();
                        break;
                }

                return _sessionStorage;
            }
        }
    }
}
