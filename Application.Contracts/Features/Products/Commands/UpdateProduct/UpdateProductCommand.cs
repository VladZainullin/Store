using Mediator;

namespace Application.Contracts.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    UpdateProductRequestRouteDto RouteDto,
    UpdateProductRequestBodyDto BodyDto) : IRequest;