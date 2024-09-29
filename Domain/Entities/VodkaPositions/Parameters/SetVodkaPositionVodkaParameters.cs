using Domain.Entities.Vodkas;

namespace Domain.Entities.VodkaPositions.Parameters;

public readonly struct SetVodkaPositionVodkaParameters
{
    public required Vodka Vodka { get; init; }
}