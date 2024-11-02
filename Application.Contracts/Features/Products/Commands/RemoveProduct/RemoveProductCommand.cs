using MediatR;

namespace Application.Contracts.Features.Commands.RemoveProduct;

public sealed record RemoveProductCommand(RemoveProductRequestRouteDto RouteDto) : IRequest;