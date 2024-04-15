using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceApp.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assm);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm));

        return services;
    }
}