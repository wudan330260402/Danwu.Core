using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageSite.Controllers
{
    /// <summary>
    /// 基类Controller
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        protected UserInfo CurrentUser { get; set; }

        /// <summary>
        /// 登录验证处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            if (CurrentUser == null && Session["UserInfo"] == null) Response.Redirect("Login/index");
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}
