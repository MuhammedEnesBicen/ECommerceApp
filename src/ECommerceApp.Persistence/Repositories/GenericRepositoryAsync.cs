using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECommerceApp.Persistence.Repositories;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
{
    protected readonly IMongoCollection<T> _collection;

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
        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public async Task<List<T>> GetAsync() =>
    await _collection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(T newProduct) =>
        await _collection.InsertOneAsync(newProduct);

    public async Task UpdateAsync(string id, T updatedProduct) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedProduct);

    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}