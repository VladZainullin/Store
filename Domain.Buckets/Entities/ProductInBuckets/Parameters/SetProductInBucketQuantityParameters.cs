namespace Domain.Buckets.Entities.ProductInBuckets.Parameters;

public readonly struct SetProductInBucketQuantityParameters
{
    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}