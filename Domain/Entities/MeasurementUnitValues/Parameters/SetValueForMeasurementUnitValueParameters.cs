namespace Domain.Entities.MeasurementUnitValues.Parameters;

public readonly struct SetValueForMeasurementUnitValueParameters
{
    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}