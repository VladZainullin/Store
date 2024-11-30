// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.AddCharacteristicToProduct;

public sealed class AddCharacteristicToProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}