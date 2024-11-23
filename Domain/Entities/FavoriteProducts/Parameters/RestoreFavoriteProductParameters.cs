namespace Domain.Entities.FavoriteProducts.Parameters;

public readonly struct RestoreFavoriteProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}