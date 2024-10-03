namespace Application.Contracts.Features.Products.Commands.UpdateProductPosition;

public sealed class UpdateProductPositionRequestBodyDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
}