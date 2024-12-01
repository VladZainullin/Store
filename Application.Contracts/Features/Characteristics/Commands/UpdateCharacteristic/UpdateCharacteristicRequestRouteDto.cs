// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Characteristics.Commands.UpdateCharacteristic;

public sealed class UpdateCharacteristicRequestRouteDto
{
    public required Guid CharacteristicId { get; init; }
}