namespace Application.Contracts.Features.Characteristics.Commands.CreateCharacteristic;

public sealed class CreateCharacteristicRequestBodyDto
{
    public required string Title { get; init; }
}