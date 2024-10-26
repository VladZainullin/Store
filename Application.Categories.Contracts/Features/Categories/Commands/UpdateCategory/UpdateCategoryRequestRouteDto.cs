namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}