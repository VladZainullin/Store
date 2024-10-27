namespace Application.Categories.Contracts.Features.Categories.Queries.GetCategoryLogo;

public sealed class GetCategoryLogoRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}