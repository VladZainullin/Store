namespace Domain.Entities.Vodkas.Parameters;

public readonly struct SetVodkaDescriptionParameters
{
    public required string Description { get; init; }
}