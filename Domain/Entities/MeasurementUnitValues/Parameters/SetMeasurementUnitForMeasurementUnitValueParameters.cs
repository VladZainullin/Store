using Domain.Entities.MeasurementUnits;

namespace Domain.Entities.MeasurementUnitValues.Parameters;

public readonly struct SetMeasurementUnitForMeasurementUnitValueParameters
{
    public required MeasurementUnit MeasurementUnit { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}