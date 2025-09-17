using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Persistence;
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

        services
            .AddAuthentication(static options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(static options =>
            {
                options.Authority = "http://localhost:8080/realms/development";
                options.Audience = "store-backend";
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
            });

        services.AddAuthorization();

        services.AddTransient<TimeProvider>(s => TimeProvider.System);

        services.AddHealthChecks();

        return services;
    }
}