using MediatR;

namespace Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;

public sealed record RemoveProductFromCartCommand(
    RemoveProductFromCartRequestRouteDto RouteDto,
    RemoveProductFromCartRequestBodyDto BodyDto) : IRequest;