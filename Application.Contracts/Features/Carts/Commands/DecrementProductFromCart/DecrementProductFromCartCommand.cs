using MediatR;

namespace Application.Contracts.Features.Carts.Commands.DecrementProductFromCart;

public sealed record DecrementProductFromCartCommand(
    DecrementProductFromCartRequestRouteDto RouteDto,
    DecrementProductFromCartRequestBodyDto BodyDto) : IRequest;