namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetTitleForAddressParameters
{
    public required string? Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}