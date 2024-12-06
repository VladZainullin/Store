using Domain.Entities.Addresses;
using Domain.Entities.Carts;
using Domain.Entities.Categories;
using Domain.Entities.Characteristics;
using Domain.Entities.Orders;
using Domain.Entities.ProductInCarts;
using Domain.Entities.ProductInCategories;
using Domain.Entities.ProductInOrders;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence;

internal sealed class DbContextAdapter(AppDbContext context) : 
    IDbContext,
    IMigrationContext,
    ITransactionContext
{
    public IDbSet<Category> Categories { get; } = new DbSetAdapter<Category>(context);
    
    public IDbSet<Product> Products { get; } = new DbSetAdapter<Product>(context);
    
    public IDbSet<Cart> Carts { get; } = new DbSetAdapter<Cart>(context);
    
    public IDbSet<ProductInCart> ProductInCarts { get; } = new DbSetAdapter<ProductInCart>(context);
    public IDbSet<Order> Orders { get; } = new DbSetAdapter<Order>(context);
    
    public IDbSet<ProductInOrder> ProductInOrders { get; } = new DbSetAdapter<ProductInOrder>(context);
    
    public IDbSet<ProductInCategory> ProductInCategories { get; } = new DbSetAdapter<ProductInCategory>(context);
    public IDbSet<Characteristic> Characteristics { get; } = new DbSetAdapter<Characteristic>(context);
    public IDbSet<Address> Addresses { get; } = new DbSetAdapter<Address>(context);

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public async Task MigrateAsync(CancellationToken cancellationToken = default)
    {
        await context.Database.MigrateAsync(cancellationToken);
    }

    public Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.CommitTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        return context.Database.RollbackTransactionAsync(cancellationToken);
    }
}