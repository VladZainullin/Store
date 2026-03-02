using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Minio;
using Serilog;
using Web.ObjectTypes;
using Web.Options;
using Web.Services;
using Web.TypeExtensions;

namespace Web;

internal static class DependencyInjection
{
    public static IHostApplicationBuilder AddWeb(this WebApplicationBuilder builder)
    {
        builder.Services.AddSerilog();

        if (builder.Environment.IsDevelopment())
        {
            builder.Host.UseDefaultServiceProvider(static options =>
            {
                options.ValidateOnBuild = true;
                options.ValidateScopes = true;
            });
        }
        
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

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<CurrentUser>();
        
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(static options =>
            {
                options.Authority = "http://localhost:8080/realms/development";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = "store-backend",
                    ValidIssuer = "store-frontend",
                };
            });

        builder.Services
            .AddGraphQLServer()
            .AddAuthorization()
            .AddQueryType<Query>()
            .AddTypeExtension<OrderQueryTypeExtension>();

        builder.Services.AddTransient<TimeProvider>(s => TimeProvider.System);

        return builder;
    }
}