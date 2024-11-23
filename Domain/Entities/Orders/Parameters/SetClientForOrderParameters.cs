// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Orders.Parameters;

public readonly struct SetClientForOrderParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}