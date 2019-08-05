using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Services;

namespace WebDemo2.Models.Entities.Filters
{
    /// <summary>
    /// Person登录认证
    /// </summary>
    public class PersonActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// Action调用用之前发生的拦截认证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["person"];
            if (cookie == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            Person p = JsonConvert.DeserializeObject<Person>(cookie.Value);
            if (p==null||p.Id<=0)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            PersonService pService = new PersonService(new PersonDao());
            Person cp = pService.GetOne(p.Id);
            if (cp == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            if (cp.PassWorld == p.PassWorld)
            {
                base.OnActionExecuting(filterContext);
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
    }
}