using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo2.Models.Entities;

namespace WebDemo2.Models.Services
{
    interface IServices<T>
    {
        IEnumerable<T> GetSome(string s,string s2);
        T GetOne(string s,string s2);

        T GetOne(long id);
        IEnumerable<T> GetAll();
    }
}
