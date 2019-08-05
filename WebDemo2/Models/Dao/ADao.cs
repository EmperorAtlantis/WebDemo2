using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebDemo2.Models.Dao
{
    public abstract class ADao<T>
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connecstring1"].ConnectionString;
        public IDbConnection connection;
        public ADao()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connString);
            }
            connection.Open();
        }

        public abstract IEnumerable<T> QuerySome(string s);

        public abstract IEnumerable<T> QueryOne(long id);

        public abstract IEnumerable<T> QueryAll();

        ~ADao()
        {
            connection.Close();
        }
    }
}