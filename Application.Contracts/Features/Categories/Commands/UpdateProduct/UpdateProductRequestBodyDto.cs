namespace Application.Contracts.Features.Categories.Commands.UpdateProduct;

public sealed class UpdateProductRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}