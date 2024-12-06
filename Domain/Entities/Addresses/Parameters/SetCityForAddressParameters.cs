namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetCityForAddressParameters
{
    public required string City { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}