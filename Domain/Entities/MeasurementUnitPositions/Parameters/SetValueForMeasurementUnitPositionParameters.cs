namespace Domain.Entities.MeasurementUnitPositions.Parameters;

public readonly struct SetValueForMeasurementUnitPositionParameters
{
    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}