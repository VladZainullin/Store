using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Domain.Entities;
using static System.Reflection.Assembly;

namespace Store.Infrastructure.Persistence;

internal sealed class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Shop> Shops => Set<Shop>();

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