using System.Reflection;
using Clients.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICurrentClient<Guid>, CurrentClientMock>();
        builder.Services.AddScoped<ICurrentDeliverer<Guid>, CurrentDelivererMock>();
        
        return builder;
    }
    
    private sealed class CurrentClientMock : ICurrentClient<Guid>
    {
        public Guid ClientId => Guid.Parse("046e343b-0d86-451d-8964-fcfdd1f16e8a");
    }
    
    private sealed class CurrentDelivererMock : ICurrentDeliverer<Guid>
    {
        public Guid DelivererId => Guid.Parse("046e343b-0d86-451d-8964-fcfdd1f16e9c");
    }
}