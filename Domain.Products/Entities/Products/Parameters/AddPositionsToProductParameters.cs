namespace Domain.Entities.Products.Parameters;

public readonly struct AddPositionsToProductParameters
{
    public required IEnumerable<PositionDto> Positions { get; init; }

    public required TimeProvider TimeProvider { get; init; }

    public readonly struct PositionDto
    {
        public required Guid MeasurementUnitPositionId { get; init; }
    }
}