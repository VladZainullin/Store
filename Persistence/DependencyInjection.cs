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
        builder.Services.AddDbContextPool<AppDbContext>(ConfigureDbContext);
        builder.Services.AddPooledDbContextFactory<AppDbContext>(ConfigureDbContext);
        
        builder.Services.AddScoped<DbContext>(sp => sp.GetRequiredService<AppDbContext>());
        builder.Services.AddScoped<DbContextAdapter<AppDbContext>>();
        builder.Services.AddScoped<IDbContext>(sp => sp.GetRequiredService<DbContextAdapter<AppDbContext>>());
        builder.Services.AddScoped<IMigrationContext>(sp => sp.GetRequiredService<DbContextAdapter<AppDbContext>>());
        builder.Services.AddScoped<ITransactionContext>(sp => sp.GetRequiredService<DbContextAdapter<AppDbContext>>());
        builder.Services.AddSingleton<IDbContextFactory, DbContextFactoryAdapter<AppDbContext>>();
        
        return builder;
    }
    
    private static void ConfigureDbContext(IServiceProvider serviceProvider, DbContextOptionsBuilder options)
    {
        var npgsqlConnectionStringBuilderOptions = serviceProvider.GetRequiredService<IOptions<NpgsqlConnectionStringBuilder>>();
        var npgsqlConnectionStringBuilder = npgsqlConnectionStringBuilderOptions.Value;
        var connectionString = npgsqlConnectionStringBuilder.ConnectionString;
        options
            .UseSnakeCaseNamingConvention()
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .UseNpgsql(connectionString, npgsqlDbContextOptionsBuilder =>
            {
                npgsqlDbContextOptionsBuilder.MigrationsAssembly("Persistence");
                npgsqlDbContextOptionsBuilder.MigrationsHistoryTable(
                    HistoryRepository.DefaultTableName,
                    npgsqlConnectionStringBuilder.SearchPath);
            })
            .UseProjectables();
    }
}