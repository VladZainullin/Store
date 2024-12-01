// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.FavoriteProduct;

public sealed class FavoriteProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}