// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryRequestBodyDto
{
    public required Guid ProductId { get; init; }
}