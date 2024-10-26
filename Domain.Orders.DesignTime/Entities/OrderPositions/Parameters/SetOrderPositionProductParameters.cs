namespace Domain.Entities.OrderPositions.Parameters;

public readonly struct SetOrderPositionProductParameters
{
    public required Guid ProductId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}