using ECommerceApp.Domain.Entities;
using ECommerceApp.Persistence.Repositories;
using Microsoft.Extensions.Options;

namespace ECommerceApp.Persistence.Services
{
    public class CategoryRepository : GenericRepositoryAsync<Category>
    {
        public CategoryRepository(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings)
        {
        }
    }
}
