﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Buckets;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(mediatorServiceConfiguration =>
        {
            mediatorServiceConfiguration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        return services;
    }
}