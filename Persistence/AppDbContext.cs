using Domain.Entities.Carts;
using Domain.Entities.Categories;
using Domain.Entities.ProductInCarts;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<Product> Products => Set<Product>();
    
    public DbSet<Cart> Carts => Set<Cart>();
    
    public DbSet<ProductInCart> ProductInCarts => Set<ProductInCart>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new ProductConfiguration())
            .ApplyConfiguration(new CategoryConfiguration())
            .ApplyConfiguration(new CartConfiguration())
            .ApplyConfiguration(new ProductInCartConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}