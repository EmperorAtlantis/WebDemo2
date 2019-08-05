using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo2.Models.Entities;

namespace WebDemo2.Controllers
{
    
    public class UserController : ApiController
    {
        [HttpGet]
        public string Login(string s)
        {

            
            var person = new Person();
            return s;
        }
        
    }
}
