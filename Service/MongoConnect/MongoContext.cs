using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MongoConnect
{
    public class MongoContext : IMongoBaseContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public MongoContext()
        {
            Client = new MongoClient(AppSettings.MongoSettings.ConnectionString);
            Database = Client.GetDatabase(AppSettings.MongoSettings.DatabaseName);
        }
    }
}
