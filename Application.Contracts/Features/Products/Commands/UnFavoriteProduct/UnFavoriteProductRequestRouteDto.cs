namespace Application.Contracts.Features.Products.Commands.UnFavoriteProduct;

public sealed class UnFavoriteProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}