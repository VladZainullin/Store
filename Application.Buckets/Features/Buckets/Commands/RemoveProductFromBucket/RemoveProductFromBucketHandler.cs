using Application.Buckets.Contracts.Features.Buckets.Commands.RemoveProductFromBucket;
using Clients.Contracts;
using Domain.Entities.Buckets.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Buckets.Queries;

namespace Application.Buckets.Features.Buckets.Commands.RemoveProductFromBucket;

internal sealed class RemoveProductFromBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<RemoveProductFromBucketCommand>
{
    public async Task Handle(RemoveProductFromBucketCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Buckets.GetAsync(new GetClientBucketParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        bucket.RemoveProduct(new RemoveProductFromBucketParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}