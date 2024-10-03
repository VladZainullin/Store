namespace Application.Contracts.Features.Products.Commands.DeleteProduct;

public sealed class DeleteProductRouteDto
{
    public required Guid ProductId { get; init; }
}