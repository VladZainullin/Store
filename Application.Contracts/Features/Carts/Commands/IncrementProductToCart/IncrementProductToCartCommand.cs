using MediatR;

namespace Application.Contracts.Features.Carts.Commands.IncrementProductToCart;

public sealed record IncrementProductToCartCommand(
    IncrementProductToCartRequestRouteDto RouteDto,
    IncrementProductToCartRequestBodyDto BodyDto) : IRequest;