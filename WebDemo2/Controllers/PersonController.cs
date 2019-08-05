using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models.Entities.Filters;

namespace WebDemo2.Controllers
{
    [PersonActionFilter]
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CheckPerson()
        {
            return View();
        }
    }
}