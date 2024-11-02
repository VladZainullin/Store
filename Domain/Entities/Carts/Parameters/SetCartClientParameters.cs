namespace Domain.Entities.Carts.Parameters;

public readonly struct SetCartClientParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}