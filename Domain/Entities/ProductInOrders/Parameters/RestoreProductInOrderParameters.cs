namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct RestoreProductInOrderParameters
{
    public required TimeProvider TimeProvider { get; init; }
}