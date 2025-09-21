using Application;
using HotChocolate.AspNetCore;
using Persistence;
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

            if (builder.Environment.IsDevelopment())
            {
                builder.Host.UseDefaultServiceProvider(static options =>
                {
                    options.ValidateOnBuild = true;
                    options.ValidateScopes = true;
                });
            }

            builder
                .AddPersistence()
                .AddApplication()
                .AddWeb();

            await using var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHealthChecks("/health");

            app.MapGraphQL().WithOptions(new GraphQLServerOptions
            {
                Tool = { Enable = false }
            });
            app.MapGet("hello", () => "Hello World").RequireAuthorization();

            await app.RunAsync();
        }
        catch (HostAbortedException)
        {
        }
        catch (Exception e)
        {
            logger.Fatal(e, "Application not started");
        }
    }
}