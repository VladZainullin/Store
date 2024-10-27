namespace Application.Buckets.Contracts.Features.Buckets.Commands.RemoveProductFromBucket;

public sealed record RemoveProductFromBucketRequestBodyDto
{
    public required int Quantity { get; init; }
}