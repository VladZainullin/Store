namespace Application.Contracts.Features.Products.Commands.RestoreProduct;

public sealed class RestoreProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}