namespace Application.Contracts.Features.Products.Commands.AddPositionsToProduct;

public sealed class AddPositionsToProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}