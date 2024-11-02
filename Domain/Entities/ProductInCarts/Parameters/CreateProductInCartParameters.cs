namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct CreateProductInCartParameters
{
    public required int Quantity { get; init; }

    public required Guid ProductId { get; init; }

    public required Guid BucketId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}