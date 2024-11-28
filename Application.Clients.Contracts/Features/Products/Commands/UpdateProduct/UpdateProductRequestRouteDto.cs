// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}