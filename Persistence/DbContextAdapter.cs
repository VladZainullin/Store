using Domain.Entities.ProductPositions;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.CategoryRepositories;
using Persistence.DbSets;

namespace Persistence;

internal sealed class DbContextAdapter(DbContext context) : 
    IDbContext,
    IMigrationContext,
    ITransactionContext
{
    public IDbSet<Product> Products { get; } =
        new DbSetAdapter<Product>(context);
    
    public IDbSet<ProductPosition> ProductPositions { get; } =
        new DbSetAdapter<ProductPosition>(context);

    public ICategoryDbSet Categories { get; } = new CategoryDbSetAdapter(context);

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return context.SaveChangesAsync(cancellationToken: cancellationToken);
    }

    public Task MigrateAsync(CancellationToken cancellationToken = default)
    {
        return context.Database.MigrateAsync(cancellationToken);
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