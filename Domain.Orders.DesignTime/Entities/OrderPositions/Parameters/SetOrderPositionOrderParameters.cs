using Domain.Entities.Orders;

namespace Domain.Entities.OrderPositions.Parameters;

public readonly struct SetOrderPositionOrderParameters
{
    public required Order Order { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}