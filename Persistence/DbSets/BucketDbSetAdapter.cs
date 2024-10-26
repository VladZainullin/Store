using Domain.Entities.Buckets;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts.DbSets.Buckets;
using Persistence.Contracts.DbSets.Buckets.Queries;

namespace Persistence.DbSets;

internal sealed class BucketDbSetAdapter(AppDbContext context) : DbSetAdapter<Bucket>(context), IBucketDbSet
{
    public Task<Bucket> GetAsync(GetClientBucketParameters parameters, CancellationToken cancellationToken = default)
    {
        var queryable = context.Buckets.AsQueryable();

        if (parameters.AsTracking)
        {
            queryable = queryable.AsTracking();
        }

        if (parameters.IncludeProducts)
        {
            queryable = queryable.Include(static b => b.Products);
        }

        return queryable.Where(b => b.ClientId == parameters.ClientId).SingleAsync(cancellationToken);
    }
}