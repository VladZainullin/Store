// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Characteristics.Commands.RemoveCharacteristic;

public sealed class RemoveCharacteristicRequestRouteDto
{
    public required Guid CharacteristicId { get; init; }
}