// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Queries.GetProduct;

public sealed class GetProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}