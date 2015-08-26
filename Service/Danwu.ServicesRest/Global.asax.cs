using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Routing;
using System.Web.SessionState;
using System.ServiceModel.Activation;

using Danwu.ServicesRest.System;

namespace Danwu.ServicesRest
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        #region Private Methods

        private void RegisterRoutes() {
            RouteTable.Routes.Add(new ServiceRoute(String.Format(ConfigurationManager.AppSettings["ServiceRouteTemplate"], typeof(UserService).Name), new WebServiceHostFactory(), typeof(UserService)));
        }


        #endregion

    }
}