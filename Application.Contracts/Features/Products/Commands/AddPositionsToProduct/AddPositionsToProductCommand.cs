using MediatR;

namespace Application.Contracts.Features.Products.Commands.AddPositionsToProduct;

public sealed record AddPositionsToProductCommand(
    AddPositionsToProductRequestRouteDto RouteDto,
    AddPositionsToProductRequestBodyDto BodyDto) : IRequest;