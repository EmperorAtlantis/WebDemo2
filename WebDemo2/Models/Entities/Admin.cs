using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebDemo2.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string AdminName { get; set; }

        public string PassWorld { get; set; }

        public bool Sex { get; set; }

        public bool IsEnable { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}