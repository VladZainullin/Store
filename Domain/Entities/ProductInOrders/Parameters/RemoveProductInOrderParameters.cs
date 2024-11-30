namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct RemoveProductInOrderParameters
{
    public required TimeProvider TimeProvider { get; init; }
}