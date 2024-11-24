namespace Domain.Entities.MeasurementUnits.Parameters;

public readonly struct RemoveMeasurementUnitParameters
{
    public required TimeProvider TimeProvider { get; init; }
}