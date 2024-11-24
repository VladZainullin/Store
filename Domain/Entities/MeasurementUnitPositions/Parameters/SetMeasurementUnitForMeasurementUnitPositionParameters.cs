using Domain.Entities.MeasurementUnits;

namespace Domain.Entities.MeasurementUnitPositions.Parameters;

public readonly struct SetMeasurementUnitForMeasurementUnitPositionParameters
{
    public required MeasurementUnit MeasurementUnit { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}