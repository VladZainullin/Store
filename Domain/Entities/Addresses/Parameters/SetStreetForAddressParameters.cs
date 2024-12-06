namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetStreetForAddressParameters
{
    public required string Street { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}