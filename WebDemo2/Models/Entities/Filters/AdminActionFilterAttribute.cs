using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Services;

namespace WebDemo2.Models.Entities.Filters
{
    public class AdminActionFilterAttribute : ActionFilterAttribute
    {
        

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies["admin"];
            if (cookie == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            Admin a = JsonConvert.DeserializeObject<Admin>(cookie.Value);
            if (a == null || a.Id <= 0)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            AdminService aService = new AdminService(new AdminDao());
            Admin ca = aService.GetOne(a.Id);
            if (ca == null)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Login");
                return;
            }
            if (ca.PassWorld == a.PassWorld)
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