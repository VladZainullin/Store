// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateCategoryLogo;

public sealed class UpdateCategoryLogoRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}