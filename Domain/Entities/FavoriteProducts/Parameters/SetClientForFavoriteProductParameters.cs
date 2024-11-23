namespace Domain.Entities.FavoriteProducts.Parameters;

public readonly struct SetClientForFavoriteProductParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}