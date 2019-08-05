using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace WebDemo2.Models.Entities.Authorize
{
    public class PersonPrincipal : IPrincipal
    {
        private Person person;
        public PersonPrincipal(Person p)
        {
            person = p;
        }
        public IIdentity Identity => person;

        public bool IsInRole(string role)
        {
            if (role == "person")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}