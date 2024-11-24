// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Queries.GetCategories;

public sealed class GetCategoriesRequestQueryDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}