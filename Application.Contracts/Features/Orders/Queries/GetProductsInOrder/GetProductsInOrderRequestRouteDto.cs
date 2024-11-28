namespace Application.Contracts.Features.Orders.Queries.GetProductsInOrder;

public sealed class GetProductsInOrderRequestRouteDto
{
    public required Guid OrderId { get; init; }
}