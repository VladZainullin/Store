using Domain.Categories.Entities.Products;
using Persistence.Contracts.DbSets.Categories;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Product> Products { get; }
    
    ICategoryDbSet Categories { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}