using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApp.Persistence.Repositories;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
{
    protected readonly IMongoCollection<T> collection;

    public GenericRepositoryAsync(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(
    mongoDbSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoDbSettings.Value.DatabaseName);

        //var collectionName = typeof(T).Name.ToLower() + "s";

        var collectionName = typeof(T).Name switch
        {
            "Product" => mongoDbSettings.Value.ProductsCollectionName,
            "Category" => mongoDbSettings.Value.CategoriesCollectionName,
            _ => mongoDbSettings.Value.ProductsCollectionName
        };
        collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAsync() =>
    await collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id) =>
        await collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T newProduct) =>
        await collection.InsertOneAsync(newProduct);

    public async Task UpdateAsync(string id, T updatedProduct) =>
        await collection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    public async Task RemoveAsync(string id) =>
        await collection.DeleteOneAsync(x => x.Id == id);
}