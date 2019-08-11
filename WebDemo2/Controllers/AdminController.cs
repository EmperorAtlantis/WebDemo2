using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models.Entities.Filters;

namespace WebDemo2.Controllers
{
    [AdminActionFilter]
    public class AdminController : Controller
    {
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}