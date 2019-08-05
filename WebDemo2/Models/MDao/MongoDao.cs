using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemo2.Models.Entities;

namespace WebDemo2.Models.MDao
{
    public static class MongoDao
    {
        private static IMongoClient client;

        public static void Initialize()
        {
            if (client == null)
            {
                client = new MongoClient();
            }

        }
        public static IMongoDatabase GetMongoDatabase()
        {
            //Initialize();
            IMongoDatabase database = client.GetDatabase("demo2");
            return database;
        }

    }
}