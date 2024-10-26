using Domain.Entities.Buckets;
using Persistence.Contracts.DbSets.Buckets.Queries;

namespace Persistence.Contracts.DbSets.Buckets;

public interface IBucketDbSet : IDbSet<Bucket>
{
    Task<Bucket> GetAsync(GetClientBucketParameters parameters, CancellationToken cancellationToken = default);
}