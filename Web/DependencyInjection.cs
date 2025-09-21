using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Persistence;
using Web.ObjectTypes;
using Web.Options;
using Web.TypeExtensions;

namespace Web;

internal static class DependencyInjection
{
    public static IHostApplicationBuilder AddWeb(this IHostApplicationBuilder builder)
    {
        if (!EF.IsDesignTime)
        {
            builder.Services.AddOptions<MinioOptions>().BindConfiguration("Minio");
            builder.Services.AddMinio(s =>
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                var minioOptionsSnapshot = serviceProvider.GetRequiredService<IOptionsSnapshot<MinioOptions>>();
                var minioOptions = minioOptionsSnapshot.Value;

                s.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
                s.WithEndpoint(minioOptions.Endpoint);
                s.WithSSL(minioOptions.Ssl);
            });
        }
        else
        {
            builder.Services.AddSingleton<IMinioClient>(s => new MinioClient());
        }

        builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>();
        
        builder.Services
            .AddAuthentication(static options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(static options =>
            {
                options.Authority = "http://localhost:8080/realms/development";
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
                    ValidAudience = "store-backend",
                    ValidIssuer = "store-frontend",
                };
            });

        builder.Services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());

        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddTypeExtension<OrderQueryTypeExtension>();

        builder.Services.AddTransient<TimeProvider>(s => TimeProvider.System);

        builder.Services.AddHealthChecks();

        return builder;
    }
}