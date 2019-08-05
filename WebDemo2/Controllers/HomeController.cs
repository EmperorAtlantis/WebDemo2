using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Entities;
using WebDemo2.Models.Entities.Authorize;
using WebDemo2.Models.MDao;
using WebDemo2.Models.Services;

namespace WebDemo2.Controllers
{
    public class HomeController : Controller
    {
        private IServices<Person> pService;
        private IServices<Admin> aService;

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckLogin(string username, string passworld, string isPOrA)
        {
            if (isPOrA == "Person")
            {
                pService = new PersonService(new PersonDao());
                Person person = pService.GetOne(username, passworld);
                if (person == null)
                {
                    return Redirect("~/Home/Login");
                }
                var database = MongoDao.GetMongoDatabase();
                var collection = database.GetCollection<BsonDocument>("People");
                collection.InsertOne(BsonDocument.Parse(person.ToString()));
                HttpCookie cookie = new HttpCookie("person");
                cookie.Value = person.ToString();
                //Response.Cookies.Add(cookie);
                HttpContext.Response.Cookies.Add(cookie);
                HttpContext.User = new PersonPrincipal(person);

                //HttpContext.Session.Add("person", person);
                //System.Web.HttpContext.Current.Session.Add("person", person);
                //TempData.Add("person", person);
                ViewData.Add(person.Id.ToString(), person);
                return RedirectToAction("Index", "Person");
            }
            else if (isPOrA == "Admin")
            {

                aService = new AdminService(new AdminDao());
                Admin admin = aService.GetOne(username, passworld);
                if (admin == null)
                {
                    return Redirect("~/Home/Login");
                }
                HttpCookie cookie = new HttpCookie("admin");
                cookie.Value = admin.ToString();
                HttpContext.Response.Cookies.Add(cookie);
                ViewData.Add(admin.Id.ToString(), admin);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View("~/Views/Home/Login.cshtml");
            }




        }
        public string GetMDB()
        {
            var database = MongoDao.GetMongoDatabase();
            if (database == null)
            {
                return "database is null";
            }
            else
            {
                return database.DatabaseNamespace.DatabaseName;
            }

        }


    }
}
