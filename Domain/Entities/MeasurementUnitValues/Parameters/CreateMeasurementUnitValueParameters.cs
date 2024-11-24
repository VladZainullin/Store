using Domain.Entities.MeasurementUnits;

namespace Domain.Entities.MeasurementUnitValues.Parameters;

public readonly struct CreateMeasurementUnitValueParameters
{
    public required MeasurementUnit MeasurementUnit { get; init; }

    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}