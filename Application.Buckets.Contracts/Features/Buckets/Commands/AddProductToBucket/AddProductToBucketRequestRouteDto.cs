namespace Application.Contracts.Features.Buckets.Commands.AddProductToBucket;

public sealed class AddProductToBucketRequestRouteDto
{
    public required Guid BucketId { get; init; }
    
    public required Guid ProductId { get; init; }
}