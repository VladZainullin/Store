namespace Application.Contracts.Features.Characteristics.Commands.CreateCharacteristic;

public sealed class CreateCharacteristicResponseDto
{
    public required Guid CharacteristicId { get; init; }
}