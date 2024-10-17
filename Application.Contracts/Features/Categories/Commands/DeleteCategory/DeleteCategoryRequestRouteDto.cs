namespace Application.Contracts.Features.Categories.Commands.DeleteCategory;

public sealed class DeleteCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}