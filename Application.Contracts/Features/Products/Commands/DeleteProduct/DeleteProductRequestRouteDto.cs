namespace Application.Contracts.Features.Products.Commands.DeleteProduct;

public sealed class DeleteProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}