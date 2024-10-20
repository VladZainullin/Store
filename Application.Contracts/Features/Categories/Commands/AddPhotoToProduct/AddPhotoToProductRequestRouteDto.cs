// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Commands.AddPhotoToProduct;

public sealed class AddPhotoToProductRequestRouteDto
{
    public required Guid CategoryId { get; init; }

    public required Guid ProductId { get; init; }
}