namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct IncrementProductInOrderProductQuantityParameters
{
    public required TimeProvider TimeProvider { get; init; }
}

public readonly struct DecrementProductInOrderProductQuantityParameters
{
    public required TimeProvider TimeProvider { get; init; }
}