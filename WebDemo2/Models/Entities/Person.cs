using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Newtonsoft.Json;

namespace WebDemo2.Models.Entities
{
    public class Person :IIdentity
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string PassWorld { get; set; }

        public string PersonInfo { get; set; }

        public bool sex { get; set; }    //1:man   2;woman

        public string Name => UserName;

        public string AuthenticationType => "person";

        public bool IsAuthenticated => true;

        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}