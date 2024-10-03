using MediatR;

namespace Application.Contracts.Features.Products.Commands.DeletePositionsFromProduct;

public record DeletePositionsFromProductCommand(
    DeletePositionsFromProductRequestRouteDto RouteDto,
    DeletePositionsFromProductRequestBodyDto BodyDto) : IRequest;