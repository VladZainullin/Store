namespace Application.Contracts.Features.Orders.Commands.CancelOrder;

public sealed class CancelOrderRequestRouteDto
{
    public required Guid OrderId { get; init; }
}