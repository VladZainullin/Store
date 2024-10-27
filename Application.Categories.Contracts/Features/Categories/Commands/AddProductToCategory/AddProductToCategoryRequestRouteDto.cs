// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Categories.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}