namespace Domain.Entities.ProductInBuckets.Parameters;

public readonly struct CreateProductInBucketParameters
{
    public required int Quantity { get; init; }

    public required Guid ProductId { get; init; }

    public required Guid BucketId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}