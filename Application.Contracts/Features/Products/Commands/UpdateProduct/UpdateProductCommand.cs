using MediatR;

namespace Application.Contracts.Features.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    UpdateProductRequestRouteDto RouteDto,
    UpdateProductRequestBodyDto BodyDto) : IRequest;