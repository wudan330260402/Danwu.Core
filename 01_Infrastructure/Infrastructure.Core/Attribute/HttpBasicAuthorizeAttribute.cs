using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Infrastructure.Core.Attribute
{
    /// <summary>
    /// (Web API安全认证)
    /// Http Base 基本认证
    /// url:http://www.cnblogs.com/parry/archive/2012/11/09/ASPNET_MVC_Web_API_HTTP_Basic_Authorize.html
    /// </summary>
    public class HttpBasicAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        //从配置文件读取用户名和密码
        private String UserName = ConfigurationManager.AppSettings["HttpBaseAuth_UserName"] ?? "wudan";
        private String PassWord = ConfigurationManager.AppSettings["HttpBaseAuth_PassWord"] ?? "wudan1020";

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);

            if (actionContext.Request.Headers.Authorization != null) {
                //获取认证信息
                String authInfo = Encoding.Default.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
                if (String.Equals(authInfo, String.Format("{0}:{1}", UserName, PassWord))) {
                    base.IsAuthorized(actionContext);
                }
                else {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            else {
                HandleUnauthorizedRequest(actionContext);
            }
        }

        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            //base.HandleUnauthorizedRequest(actionContext);
            var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
            throw new System.Web.Http.HttpResponseException(challengeMessage);
        }
    }
}
