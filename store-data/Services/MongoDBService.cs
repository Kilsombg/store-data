using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using store_data.Models;

namespace store_data.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<BsonDocument> _laptopCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _laptopCollection = database.GetCollection<BsonDocument>(mongoDBSettings.Value.CollectionName);

            TestConnection(client);
        }


        public async void TestConnection(MongoClient client)
        {
            var databases = await client.ListDatabaseNames().ToListAsync();
            Console.WriteLine(databases);
        }
    }
}
