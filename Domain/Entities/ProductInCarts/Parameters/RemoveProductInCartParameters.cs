namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct RemoveProductInCartParameters
{
    public required TimeProvider TimeProvider { get; init; }
}