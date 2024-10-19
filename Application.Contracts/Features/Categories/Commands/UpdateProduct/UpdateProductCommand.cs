using MediatR;

namespace Application.Contracts.Features.Categories.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    UpdateProductRequestRouteDto RouteDto,
    UpdateProductRequestBodyDto BodyDto) : IRequest;