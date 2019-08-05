using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Entities;

namespace WebDemo2.Models.Services
{
    public class PersonService : IServices<Person>
    {
        private ADao<Person> dao;
        public PersonService(ADao<Person> pdao)
        {
            dao = pdao;
        }

        public IEnumerable<Person> GetAll()
        {
            return dao.QueryAll();
        }

        public Person GetOne()
        {
            throw new NotImplementedException();
        }

        public Person GetOne(string name, string passwrold)
        {
            Person person = null;
            IEnumerable<Person> people = dao.QuerySome(name);
            if (people == null)
            {
                return null;
            }
            foreach (Person p in people)
            {
                if (p.PassWorld == passwrold.Trim())
                {
                    person = p;
                    break;
                }
            }
            return person;
        }

        public Person GetOne(long id)
        {
            IEnumerable<Person> people= dao.QueryOne(id);
            if (people.Count() != 1)
            {
                return null;
            }
            return people.First();
        }

        public IEnumerable<Person> GetSome()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetSome(string s, string s2)
        {
            throw new NotImplementedException();
        }
    }
}