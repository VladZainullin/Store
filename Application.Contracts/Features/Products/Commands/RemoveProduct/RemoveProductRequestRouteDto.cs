// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.RemoveProduct;

public sealed class RemoveProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}