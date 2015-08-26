using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;

namespace Infrastructure.Utility
{
    public class HttpWebAPI
    {
        public static string apiurl = System.Configuration.ConfigurationManager.AppSettings["apiurl"];
        public static HttpClient HttpWingClient()
       {
           HttpClient client = new HttpClient(new RequestUpHandler() { InnerHandler = new HttpClientHandler() });
           client.BaseAddress = new Uri(apiurl);
           return client;
       
       }
    }
}