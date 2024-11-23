namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryResponseDto
{
    public required Guid ProductInCategoryId { get; init; }
}