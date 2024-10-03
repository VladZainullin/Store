using MediatR;

namespace Application.Contracts.Features.Products.Commands.UpdateProductPosition;

public sealed record UpdateProductPositionCommand(
    UpdateProductPositionRequestRouteDto RouteDto,
    UpdateProductPositionRequestBodyDto BodyDto) : IRequest;