using Domain.Entities.MeasurementUnits;

namespace Domain.Entities.MeasurementUnitPositions.Parameters;

public readonly struct CreateMeasurementUnitPositionParameters
{
    public required MeasurementUnit MeasurementUnit { get; init; }

    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}