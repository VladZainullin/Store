using Application.Buckets.Contracts.Features.Buckets.Commands.CleanBucket;
using Clients.Contracts;
using Domain.Buckets.Entities.Buckets.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Buckets.Queries;

namespace Application.Buckets.Features.Buckets.Commands.CleanBucket;

internal sealed class CleanBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : IRequestHandler<CleanBucketCommand>
{
    public async Task Handle(CleanBucketCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Buckets.GetAsync(new GetClientBucketParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = false
        }, cancellationToken);

        bucket.Clean(new CleanBucketParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}