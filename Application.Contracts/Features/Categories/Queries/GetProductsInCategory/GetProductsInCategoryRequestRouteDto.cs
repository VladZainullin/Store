// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Queries.GetProductsInCategory;

public sealed class GetProductsInCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}