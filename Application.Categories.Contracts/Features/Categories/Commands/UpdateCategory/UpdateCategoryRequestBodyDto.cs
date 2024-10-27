namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryRequestBodyDto
{
    public required string Title { get; init; }
}