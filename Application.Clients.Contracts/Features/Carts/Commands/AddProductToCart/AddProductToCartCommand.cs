using MediatR;

namespace Application.Contracts.Features.Carts.Commands.AddProductToCart;

public sealed record AddProductToCartCommand(
    AddProductToCartRequestRouteDto RouteDto,
    AddProductToCartRequestBodyDto BodyDto) : IRequest;