using Domain.Entities.Vodkas;

namespace Domain.Entities.VodkaPositions.Parameters;

public readonly struct CreateVodkaPositionParameters
{
    public required Vodka Vodka { get; init; }

    public required Guid MeasurementUnitPositionId { get; init; }
}