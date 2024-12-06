// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Addresses.Parameters;

public readonly struct RestoreAddressParameters
{
    public required TimeProvider TimeProvider { get; init; }
}