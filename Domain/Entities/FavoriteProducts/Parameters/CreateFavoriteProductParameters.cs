using Domain.Entities.Products;

namespace Domain.Entities.FavoriteProducts.Parameters;

public readonly struct CreateFavoriteProductParameters
{
    public required Product Product { get; init; }

    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}