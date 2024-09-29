namespace Domain.Entities.VodkaPositions.Parameters;

public readonly struct SetVodkaPositionMeasurementUnitPositionIdParameters
{
    public required Guid MeasurementUnitId { get; init; }
}