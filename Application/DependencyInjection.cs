using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(static c =>
        {
            c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        return services;
    }
}