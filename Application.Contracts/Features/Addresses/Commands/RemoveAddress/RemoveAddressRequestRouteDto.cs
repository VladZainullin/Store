namespace Application.Contracts.Features.Addresses.Commands.RemoveAddress;

public sealed class RemoveAddressRequestRouteDto
{
    public required Guid AddressId { get; init; }
}