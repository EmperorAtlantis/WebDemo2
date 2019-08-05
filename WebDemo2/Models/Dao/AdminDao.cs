using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo2.Models.Entities;
using Dapper;

namespace WebDemo2.Models.Dao
{
    public class AdminDao : ADao<Admin>
    {
        public override IEnumerable<Admin> QueryAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Admin> QueryOne(long id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Admin> QuerySome(string s)
        {
            return connection.Query<Admin>("select * from Admin where userName=@username", new { username = s });
        }
    }
}