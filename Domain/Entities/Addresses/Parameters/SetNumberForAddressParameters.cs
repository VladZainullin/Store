namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetNumberForAddressParameters
{
    public required string Number { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}