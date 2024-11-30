namespace Domain.Entities.Orders.Parameters;

public readonly struct DeliveringOrderParameters
{
    public required Guid DelivererId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}