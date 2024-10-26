using Domain.Entities.Orders;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Domain.Entities.OrderPositions.Parameters;

public readonly struct CreateOrderPositionParameters
{
    public required Guid ProductId { get; init; }

    public required Order Order { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}