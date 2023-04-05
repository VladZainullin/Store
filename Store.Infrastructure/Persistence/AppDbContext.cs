using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Reflection.Assembly;

namespace Store.Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
        
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Load("Store.Infrastructure"));

        base.OnModelCreating(modelBuilder);
    }
}