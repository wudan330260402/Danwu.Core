using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Infrastructure.Utility
{
    public static class MD5Helper
    {

        public static string md5(string s)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
         
        } 
    }
}