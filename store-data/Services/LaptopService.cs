using MongoDB.Bson;
using MongoDB.Driver;
using store_data.Models.Mongo;

namespace store_data.Services
{
    public class LaptopService
    {
        public IMongoCollection<LaptopModel> _laptopCollection;
        public LaptopService(MongoDBService mongoDBService) { 
            _laptopCollection = mongoDBService.GetLaptopCollection();
        }

        public async Task<IEnumerable<LaptopModel>> GetAsync()
        {
            return await _laptopCollection.Find(new BsonDocument()).ToListAsync();   
        }

        public async Task AddOneAsync(LaptopModel laptop)
        {
            await _laptopCollection.InsertOneAsync(laptop);
            return;
        }
    }
}
