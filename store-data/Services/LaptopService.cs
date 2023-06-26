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

        public async Task<IEnumerable<LaptopModel>> GetAsync(int limit = 1000)
        {
            return await _laptopCollection.Find(new BsonDocument()).Limit(limit).ToListAsync();   
        }
        public async Task AddOneAsync(LaptopModel laptop)
        {
            laptop = TransformLaptop(laptop);
            await _laptopCollection.InsertOneAsync(laptop);
            return;
        }


        private LaptopModel TransformLaptop(LaptopModel laptop)
        {
           laptop.Price = Math.Round(laptop.Price, 2);
            return laptop;
        }
    }
}
