// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.ProductInBuckets.Parameters;

public readonly struct SetProductInBucketBucketParameters
{
    public required Guid BucketId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}