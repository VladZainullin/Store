using MediatR;

namespace Application.Contracts.Features.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand : IRequest<CreateOrderResponseDto>;