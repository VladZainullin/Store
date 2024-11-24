namespace Domain.Entities.MeasurementUnitPositions.Parameters;

public readonly struct RestoreMeasurementUnitPositionParameters
{
    public required TimeProvider TimeProvider { get; init; }
}