using Domain.Entities.Products;

namespace Domain.Entities.FavoriteProducts.Parameters;

public readonly struct SetProductForFavoriteProductParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}