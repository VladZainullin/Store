namespace Domain.Entities.MeasurementUnits.Parameters;

public sealed class SetShortTitleForMeasurementUnitParameters
{
    public required string ShortTitle { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}