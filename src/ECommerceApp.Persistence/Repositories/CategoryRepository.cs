using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Domain.Entities;
using Microsoft.Extensions.Options;

namespace ECommerceApp.Persistence.Repositories;

public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
{
    public CategoryRepository(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings)
    {
    }
}
