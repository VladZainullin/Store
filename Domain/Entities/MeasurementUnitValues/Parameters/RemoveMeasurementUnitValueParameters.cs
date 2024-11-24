namespace Domain.Entities.MeasurementUnitValues.Parameters;

public readonly struct RemoveMeasurementUnitValueParameters
{
    public required TimeProvider TimeProvider { get; init; }
}