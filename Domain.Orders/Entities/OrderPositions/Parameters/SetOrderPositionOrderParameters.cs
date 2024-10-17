using Domain.Orders.Entities.Orders;

namespace Domain.Orders.Entities.OrderPositions.Parameters;

public readonly struct SetOrderPositionOrderParameters
{
    public required Order Order { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}