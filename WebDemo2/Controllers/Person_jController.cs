using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Entities;
using WebDemo2.Models.Services;

namespace WebDemo2.Controllers
{
    public class Person_jController : ApiController
    {
        public IEnumerable<Person> GetPeople()
        {
            PersonService personService = new PersonService(new PersonDao());
            return personService.GetAll();
        }
    }
}
