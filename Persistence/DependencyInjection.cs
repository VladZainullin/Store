using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Npgsql;
using Persistence.Contracts;

namespace Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOptions<NpgsqlConnectionStringBuilder>().BindConfiguration("Postgres");
        builder.Services.AddDbContextPool<AppDbContext>((sp, options) =>
        {
            var npgsqlConnectionStringBuilderOptions = sp.GetRequiredService<IOptions<NpgsqlConnectionStringBuilder>>();
            var npgsqlConnectionStringBuilder = npgsqlConnectionStringBuilderOptions.Value;
            var connectionString = npgsqlConnectionStringBuilder.ConnectionString;
            options
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseNpgsql(connectionString, ob =>
                {
                    ob.MigrationsAssembly("Persistence");
                    ob.MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        npgsqlConnectionStringBuilder.SearchPath);
                })
                .UseProjectables();
        });
        
        builder.Services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        builder.Services.AddScoped<DbContextAdapter>();
        builder.Services.AddScoped<IDbContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        builder.Services.AddScoped<IMigrationContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        builder.Services.AddScoped<ITransactionContext>(sp => sp.GetRequiredService<DbContextAdapter>());
        
        return builder;
    }
}