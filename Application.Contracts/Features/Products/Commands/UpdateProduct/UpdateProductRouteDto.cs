namespace Application.Contracts.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductRouteDto
{
    public required Guid ProductId { get; init; }
}