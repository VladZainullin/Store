// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Categories.Contracts.Features.Categories.Commands.RemoveCategory;

public sealed class RemoveCategoryRequestRouteDto
{
    public required Guid CategoryId { get; init; }
}