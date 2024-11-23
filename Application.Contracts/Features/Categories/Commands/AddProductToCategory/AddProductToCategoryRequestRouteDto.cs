namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryRequestRouteDto
{
    public required Guid ProductId { get; init; }

    public required Guid CategoryId { get; init; }
}