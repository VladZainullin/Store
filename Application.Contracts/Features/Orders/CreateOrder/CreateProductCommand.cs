namespace Application.Contracts.Features.Orders.CreateOrder;

public sealed class CreateProductCommand
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required int Quantity { get; init; }

    public required decimal Cost { get; init; }
}