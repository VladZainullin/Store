namespace Application.Contracts.Features.Categories.Queries.GetProductsInCategory;

public sealed class GetProductsInCategoryRequestQueryDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}