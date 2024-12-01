namespace Application.Contracts.Features.Categories.Commands.RestoreProductFromCategory;

public sealed class RestoreProductFromCategoryRequestRouteDto
{
    public required Guid ProductId { get; init; }

    public required Guid CategoryId { get; init; }
}