namespace Domain.Entities.Vodkas.Parameters;

public sealed class CreateVodkaParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}