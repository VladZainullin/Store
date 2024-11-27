namespace Domain.Entities.Carts.Parameters;

public sealed class CreateOrderFromCartParameters
{
    public required TimeProvider TimeProvider { get; init; }
}