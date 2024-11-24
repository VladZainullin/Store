namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct SetQuantityForProductInCartParameters
{
    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}