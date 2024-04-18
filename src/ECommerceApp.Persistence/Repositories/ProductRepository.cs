using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using Microsoft.Extensions.Options;

namespace ECommerceApp.Persistence.Repositories;

public class ProductRepository : GenericRepositoryAsync<Product>, IProductRepository
{
    public ProductRepository(
        IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings)
    {
    }

}
