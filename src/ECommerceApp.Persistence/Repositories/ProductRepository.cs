using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace ECommerceApp.Persistence.Repositories;

public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
    //private readonly IMongoCollection<Product> _productsCollection;

    public ProductRepository(
        IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings)
    {
        //var mongoClient = new MongoClient(
        //    mongoDbSettings.Value.ConnectionString);

        //var mongoDatabase = mongoClient.GetDatabase(
        //    mongoDbSettings.Value.DatabaseName);

        //_productsCollection = mongoDatabase.GetCollection<Product>(
        //    mongoDbSettings.Value.ProductsCollectionName);
    }

    //public async Task<List<Product>> GetAsync() =>
    //    await _productsCollection.Find(_ => true).ToListAsync();

    //public async Task<Product?> GetAsync(string id) =>
    //    await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    //public async Task CreateAsync(Product newProduct) =>
    //    await _productsCollection.InsertOneAsync(newProduct);

    //public async Task UpdateAsync(string id, Product updatedProduct) =>
    //    await _productsCollection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    //public async Task RemoveAsync(string id) =>
    //    await _productsCollection.DeleteOneAsync(x => x.Id == id);
}
