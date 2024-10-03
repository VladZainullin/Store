using MediatR;

namespace Application.Contracts.Features.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(DeleteProductRouteDto RouteDto) : IRequest;