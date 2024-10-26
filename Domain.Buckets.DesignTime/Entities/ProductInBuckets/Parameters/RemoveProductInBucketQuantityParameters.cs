namespace Domain.Entities.ProductInBuckets.Parameters;

public readonly struct RemoveProductInBucketQuantityParameters
{
    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}