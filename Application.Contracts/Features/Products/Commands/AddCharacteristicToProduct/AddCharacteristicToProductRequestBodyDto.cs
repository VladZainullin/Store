// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Products.Commands.AddCharacteristicToProduct;

public sealed class AddCharacteristicToProductRequestBodyDto
{
    public required Guid CharacteristicId { get; init; }
    
    public required string Value { get; init; }
}