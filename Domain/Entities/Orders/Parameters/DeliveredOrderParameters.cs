// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Orders.Parameters;

public readonly struct DeliveredOrderParameters
{
    public required TimeProvider TimeProvider { get; init; }
}