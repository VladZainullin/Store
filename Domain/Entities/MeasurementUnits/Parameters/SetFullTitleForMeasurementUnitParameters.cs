namespace Domain.Entities.MeasurementUnits.Parameters;

public sealed class SetFullTitleForMeasurementUnitParameters
{
    public required string FullTitle { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}