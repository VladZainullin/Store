namespace Application.Contracts.Features.Buckets.Commands.RemoveProductFromBucket;

public sealed record RemoveProductFromBucketRequestRouteDto
{
    public required Guid ProductId { get; init; }
}