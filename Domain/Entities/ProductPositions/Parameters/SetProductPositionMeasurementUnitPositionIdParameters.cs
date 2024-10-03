namespace Domain.Entities.ProductPositions.Parameters;

public readonly struct SetProductPositionMeasurementUnitPositionIdParameters
{
    public required Guid MeasurementUnitId { get; init; }
}