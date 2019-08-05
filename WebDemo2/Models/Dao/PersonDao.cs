using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo2.Models.Entities;
using Dapper;

namespace WebDemo2.Models.Dao
{
    public class PersonDao : ADao<Person> 
    {
        public override IEnumerable<Person> QuerySome(string name)
        {
            IEnumerable<Person> people = connection.Query<Person>("select * from Person where userName=@username", new { username = name });
            return people;
        }

        public override IEnumerable<Person> QueryOne(long id)
        {
            IEnumerable<Person> people = connection.Query<Person>("select * from Person where Id=@pid", new { pid = id });
            return people;
        }

        public override IEnumerable<Person> QueryAll()
        {
            return connection.Query<Person>("select * from Person");
        }
    }
}