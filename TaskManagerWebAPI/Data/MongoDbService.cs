using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace TaskManagerWebAPI.MongoDbService
{
    public class MongoDbService
    {
        private readonly IConfiguration _configration;
        private readonly IMongoDatabase? _database;
        public MongoDbService(IConfiguration configuration)
        {            
            _configration = configuration;

            var connectionString = _configration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);   
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);           
        }

        public IMongoDatabase? Database => _database;

    }
}
