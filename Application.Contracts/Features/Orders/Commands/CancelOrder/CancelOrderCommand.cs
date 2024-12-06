using Mediator;

namespace Application.Contracts.Features.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand(CancelOrderRequestRouteDto Route) : IRequest;