using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo2.Models.Dao;
using WebDemo2.Models.Entities;

namespace WebDemo2.Models.Services
{
    public class AdminService : IServices<Admin>
    {
        private ADao<Admin> A_dao;
        private ADao<Person> P_dao;
        
        public AdminService(ADao<Admin> adao)
        {
            A_dao = adao;
        }

        /// <summary>
        /// 为admin查改person信息提供的方式
        /// </summary>
        /// <param name="adao"></param>
        /// <param name="pdao"></param>
        public AdminService(ADao<Admin> adao,ADao<Person> pdao)
        {
            P_dao = pdao;
            A_dao = adao;
        }
        
        

        public IEnumerable<Admin> GetAdmins(string name)
        {
            return A_dao.QuerySome(name);
        }

        /// <summary>
        /// 为管理员显示所有普通用户信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetAllPerson()
        {
            if (P_dao == null)
            {
                return null;
            }
            return P_dao.QueryAll();

        }

        public Admin GetOne(string name, string passworld)
        {
            Admin admin = null;
            IEnumerable<Admin> admins= A_dao.QuerySome(name);
            if (admins == null)
            {
                return null;
            }
            foreach(Admin a in admins)
            {
                if (a.PassWorld == passworld.Trim())
                {
                    admin = a;
                    break;
                }
            }
            return admin;

        }

        public Admin GetOne(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> GetSome(string s, string s2)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Admin> IServices<Admin>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}