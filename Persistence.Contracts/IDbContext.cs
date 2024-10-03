using Domain.Entities;
using Domain.Entities.Products;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Product> Products { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}