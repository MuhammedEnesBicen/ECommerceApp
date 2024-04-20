using ECommerceApp.Application.Services.Repositories;
using ECommerceApp.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceApp.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {

        services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}