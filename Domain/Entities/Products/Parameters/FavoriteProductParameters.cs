// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Parameters;

public readonly struct FavoriteProductParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}