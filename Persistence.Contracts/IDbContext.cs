using Domain.Entities;
using Domain.Entities.ProductPositions;
using Domain.Entities.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Product> Products { get; }
    
    IDbSet<ProductPosition> ProductPositions { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}