using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utility
{
    public class RequestUpHandler : DelegatingHandler
    {

        public static string _appkey = System.Configuration.ConfigurationManager.AppSettings["appkey"];
        public static string _appsecrect = System.Configuration.ConfigurationManager.AppSettings["appsecret"];
        public static string _sessionkey = System.Configuration.ConfigurationManager.AppSettings["sessionkey"];

        //public static string _appkey = "boris";
        //public static string _appsecrect = "123456";
        //public static string _sessionkey = "123456";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            request.Headers.Add("appkey", _appkey);
            request.Headers.Add("appsecrect", _appsecrect);
            request.Headers.Add("sessionkey", _sessionkey);
            return base.SendAsync(request, cancellationToken);
        }

    }
}
