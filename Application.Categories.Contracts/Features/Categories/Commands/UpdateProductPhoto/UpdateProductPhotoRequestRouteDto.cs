// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateProductPhoto;

public sealed class UpdateProductPhotoRequestRouteDto
{
    public required Guid CategoryId { get; init; }

    public required Guid ProductId { get; init; }
}