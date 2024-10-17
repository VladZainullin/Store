namespace Domain.Orders.Entities.Orders.Parameters;

public readonly struct CreateOrderParameters
{
    public required TimeProvider TimeProvider { get; init; }
}