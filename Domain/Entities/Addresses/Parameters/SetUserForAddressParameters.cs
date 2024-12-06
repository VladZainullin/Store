// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Addresses.Parameters;

public readonly struct SetUserForAddressParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}