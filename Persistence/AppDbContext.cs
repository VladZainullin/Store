using Domain.Categories.Entities.Categories;
using Domain.Categories.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}