namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct RestoreProductInCartParameters
{
    public required TimeProvider TimeProvider { get; init; }
}