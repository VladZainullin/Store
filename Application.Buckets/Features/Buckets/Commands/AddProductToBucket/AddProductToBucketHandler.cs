using Application.Buckets.Contracts.Features.Buckets.Commands.AddProductToBucket;
using Clients.Contracts;
using Domain.Entities.Buckets.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Buckets.Queries;

namespace Application.Features.Buckets.Commands.AddProductToBucket;

internal sealed class AddProductToBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<AddProductToBucketCommand>
{
    public async Task Handle(AddProductToBucketCommand request, CancellationToken cancellationToken)
    {
        var bucket = await context.Buckets.GetAsync(new GetClientBucketParameters
        {
            ClientId = currentClient.ClientId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        bucket.AddProduct(new AddProductToBucketParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}