namespace Domain.Entities.Carts.Parameters;

public readonly struct CreateCartParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}