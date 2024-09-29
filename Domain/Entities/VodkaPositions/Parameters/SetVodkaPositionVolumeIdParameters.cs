namespace Domain.Entities.VodkaPositions.Parameters;

public readonly struct SetVodkaPositionVolumeIdParameters
{
    public required Guid VolumeId { get; init; }
}