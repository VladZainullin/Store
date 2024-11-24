namespace Domain.Entities.MeasurementUnitPositions.Parameters;

public readonly struct RemoveMeasurementUnitPositionParameters
{
    public required TimeProvider TimeProvider { get; init; }
}