using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using store_data.Models;

namespace store_data.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Models.Mongo.LaptopModel> _laptopCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _laptopCollection = database.GetCollection<Models.Mongo.LaptopModel>(mongoDBSettings.Value.LaptopCollectionName);
        }

        public IMongoCollection<Models.Mongo.LaptopModel> GetLaptopCollection()
        {
            return _laptopCollection;
        }
    }
}
