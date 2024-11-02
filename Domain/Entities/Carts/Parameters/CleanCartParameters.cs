namespace Domain.Entities.Carts.Parameters;

public readonly struct CleanCartParameters
{
    public required TimeProvider TimeProvider { get; init; }
}