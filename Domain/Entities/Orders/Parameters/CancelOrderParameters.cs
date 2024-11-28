namespace Domain.Entities.Orders.Parameters;

public sealed class CancelOrderParameters
{
    public required TimeProvider TimeProvider { get; init; }
}