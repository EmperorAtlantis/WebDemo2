using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo2.Models.Entities.Authorize
{
    /// <summary>
    /// Person权限管理
    /// </summary>
    public class PersonAuthorizeAttribute : AuthorizeAttribute
    {
        
        public override object TypeId => "person";

        /// <summary>
        /// 验证用户是否有权限执行action
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie cookie= httpContext.Request.Cookies["person"];
            if (cookie == null)
            {
                return false;
            }
            if (httpContext.User.Identity.AuthenticationType != "person")
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// 当AuthorizeCore()返回false时,执行此方法
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("~/Home/Login");
        }

        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }
    }
}