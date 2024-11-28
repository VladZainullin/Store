// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Queries.GetProducts;

public sealed class GetProductsRequestQueryDto
{
    public required int? Skip { get; init; }

    public required int? Take { get; init; }
}