// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.MeasurementUnits.Parameters;

public sealed class CreateMeasurementUnitParameters
{
    public required string FullTitle { get; init; }

    public required string ShortTitle { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}