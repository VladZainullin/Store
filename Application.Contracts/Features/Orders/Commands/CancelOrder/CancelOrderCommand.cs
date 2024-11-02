using MediatR;

namespace Application.Contracts.Features.Orders.Commands.CancelOrder;

public sealed record CancelOrderCommand : IRequest;