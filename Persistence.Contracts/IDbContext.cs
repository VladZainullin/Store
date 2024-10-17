using Domain.Entities.ProductPositions;
using Domain.Entities.Products;
using Persistence.Contracts.DbSets.CategoryRepositories;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Product> Products { get; }
    
    IDbSet<ProductPosition> ProductPositions { get; }
    
    ICategoryDbSet Categories { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}