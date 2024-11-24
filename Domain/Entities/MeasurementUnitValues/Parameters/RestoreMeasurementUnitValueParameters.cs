namespace Domain.Entities.MeasurementUnitValues.Parameters;

public readonly struct RestoreMeasurementUnitValueParameters
{
    public required TimeProvider TimeProvider { get; init; }
}