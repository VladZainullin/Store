using Application;
using Persistence;
using Persistence.Contracts;
using Serilog;

namespace Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();
        
        try
        {
            builder.Host.UseSerilog(logger);

            builder.Services
                .AddPersistenceServices()
                .AddApplicationServices()
                .AddWebServices();

            await using var app = builder.Build();

            await using var scope = app.Services.CreateAsyncScope();
            var migrationContext = scope.ServiceProvider.GetRequiredService<IMigrationContext>();
            await migrationContext.MigrateAsync();

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHealthChecks("/health");
            
            app.MapGet("hello", () => "Hello World").RequireAuthorization();

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