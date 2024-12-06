using Mediator;

namespace Application.Contracts.Features.Products.Commands.RemoveProduct;

public sealed record RemoveProductCommand(RemoveProductRequestRouteDto RouteDto) : IRequest;