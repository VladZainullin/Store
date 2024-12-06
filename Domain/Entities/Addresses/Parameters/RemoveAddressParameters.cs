// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Addresses.Parameters;

public readonly struct RemoveAddressParameters
{
    public required TimeProvider TimeProvider { get; init; }
}