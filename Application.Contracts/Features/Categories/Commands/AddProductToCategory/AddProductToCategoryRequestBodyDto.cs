// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryRequestBodyDto
{
    public required string Title { get; init; }
}