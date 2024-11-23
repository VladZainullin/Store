namespace Domain.Entities.FavoriteProducts.Parameters;

public readonly struct RemoveFavoriteProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}