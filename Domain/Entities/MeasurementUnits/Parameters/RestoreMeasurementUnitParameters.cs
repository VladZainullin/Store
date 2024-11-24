namespace Domain.Entities.MeasurementUnits.Parameters;

public readonly struct RestoreMeasurementUnitParameters
{
    public required TimeProvider TimeProvider { get; init; }
}