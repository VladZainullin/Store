using Domain.Entities.Deliverers;

namespace Domain.Entities.Orders.Parameters;

public readonly struct DeliveringOrderParameters
{
    public required Deliverer Deliverer { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}