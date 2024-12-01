// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.RemoveCharacteristicFromProduct;

public sealed class RemoveCharacteristicFromProductRouteDto
{
    public required Guid ProductId { get; init; }

    public required Guid CharacteristicId { get; init; }
}