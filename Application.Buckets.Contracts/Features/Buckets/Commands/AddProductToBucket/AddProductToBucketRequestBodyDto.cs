namespace Application.Buckets.Contracts.Features.Buckets.Commands.AddProductToBucket;

public sealed class AddProductToBucketRequestBodyDto
{
    public required int Quantity { get; init; }
}