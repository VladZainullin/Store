using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minio;
using Persistence;
using Web.Middlewares;
using Web.Options;

namespace Web;

internal static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        if (!EF.IsDesignTime)
        {
            services.AddOptions<MinioOptions>().BindConfiguration("Minio");
            services.AddMinio(s =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var minioOptionsSnapshot = serviceProvider.GetRequiredService<IOptionsSnapshot<MinioOptions>>();
                var minioOptions = minioOptionsSnapshot.Value;
            
                s.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
                s.WithEndpoint(minioOptions.Endpoint);
                s.WithSSL(minioOptions.Ssl);
            });   
        }
        else
        {
            services.AddSingleton<IMinioClient>(s => new MinioClient());
        }

        services.AddHealthChecks().AddDbContextCheck<AppDbContext>();
        services.AddProblemDetails();
        
        services.AddTransient<TimeProvider>(s => TimeProvider.System);

        services.AddHealthChecks();

        services.AddScoped<TransactionMiddleware>();
        services.AddControllers();
        
        return services;
    }
}