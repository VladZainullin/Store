using Domain.Entities.ProductPositions;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductPosition> ProductPositions => Set<ProductPosition>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductPositionConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}