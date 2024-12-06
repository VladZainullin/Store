namespace Domain.Entities.Addresses.Parameters;

public sealed class SetHouseForAddressParameters
{
    public required string House { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}