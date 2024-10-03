using MediatR;

namespace Application.Contracts.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(UpdateProductRouteDto RouteDto, UpdateProductBodyDto BodyDto) : IRequest;