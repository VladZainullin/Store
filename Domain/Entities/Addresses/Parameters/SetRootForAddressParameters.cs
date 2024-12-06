namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetRootForAddressParameters
{
    public required string Root { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}