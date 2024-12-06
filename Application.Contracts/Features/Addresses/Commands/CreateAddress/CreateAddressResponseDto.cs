namespace Application.Contracts.Features.Addresses.Commands.CreateAddress;

public sealed class CreateAddressResponseDto
{
    public required Guid AddressId { get; init; }
}