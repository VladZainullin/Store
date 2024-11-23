using System.Reflection;
using Clients.Contracts;
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
        
        services.AddScoped<ICurrentClient<Guid>, CurrentClientMock>();
        
        return services;
    }
    
    public sealed class CurrentClientMock : ICurrentClient<Guid>
    {
        public Guid ClientId => Guid.Parse("046e343b-0d86-451d-8964-fcfdd1f16e8a");
    }
}