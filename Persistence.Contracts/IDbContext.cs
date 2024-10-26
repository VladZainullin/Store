using Persistence.Contracts.DbSets.Buckets;
using Persistence.Contracts.DbSets.Categories;

namespace Persistence.Contracts;

public interface IDbContext
{
    ICategoryDbSet Categories { get; }
    
    IBucketDbSet Buckets { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}