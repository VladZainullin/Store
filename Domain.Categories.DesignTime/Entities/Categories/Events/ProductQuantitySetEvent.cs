namespace Domain.Entities.Categories.Events;

public sealed class ProductQuantitySetEvent
{
    public required Guid ProductId { get; init; }

    public required decimal Quantity { get; init; }
}