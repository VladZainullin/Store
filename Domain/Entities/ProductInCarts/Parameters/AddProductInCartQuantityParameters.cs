namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct AddProductInCartQuantityParameters
{
    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}