using ECommerceApp.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApp.Infrastructure.Services
{
    public class CategoryRepository
    {
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CategoryRepository(
            IOptions<MongoDbSettings> CategoryStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                CategoryStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                CategoryStoreDatabaseSettings.Value.DatabaseName);

            _categoriesCollection = mongoDatabase.GetCollection<Category>(
                CategoryStoreDatabaseSettings.Value.CategoriesCollectionName);
        }

        public async Task<List<Category>> GetAsync() =>
            await _categoriesCollection.Find(_ => true).ToListAsync();

        public async Task<Category?> GetAsync(string id) =>
            await _categoriesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Category newCategory) =>
            await _categoriesCollection.InsertOneAsync(newCategory);

        public async Task UpdateAsync(string id, Category updatedCategory) =>
            await _categoriesCollection.ReplaceOneAsync(x => x.Id == id, updatedCategory);

        public async Task RemoveAsync(string id) =>
            await _categoriesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
