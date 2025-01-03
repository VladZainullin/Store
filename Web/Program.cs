using Application;
using Persistence;
using Persistence.Contracts;
using Scalar.AspNetCore;
using Serilog;
using Web.Middlewares;

namespace Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        await using var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog(logger);

            builder.Services
                .AddPersistenceServices()
                .AddApplicationServices()
                .AddWebServices();

            await using var app = builder.Build();

            await using var scope = app.Services.CreateAsyncScope();
            var migrationContext = scope.ServiceProvider.GetRequiredService<IMigrationContext>();
            await migrationContext.MigrateAsync();
            
            app.UseExceptionHandler();
            
            if (app.Environment.IsProduction())
            {
                app.UseHsts();
            }
            
            app.UseHealthChecks("/health");

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseHealthChecks("/health");

            app.MapOpenApi();
            app.MapScalarApiReference(static s =>
            {
                s.Theme = ScalarTheme.None;
                s.HiddenClients = true;
                s.HideDownloadButton = true;
                s.HideDarkModeToggle = false;
            });
            
            app.UseMiddleware<TransactionMiddleware>();
            
            app.MapControllers();

            await app.RunAsync();
        }
        catch (HostAbortedException)
        {
        }
        catch (Exception e)
        {
            logger.Fatal("Application not started. {error}", e);
        }
    }
}