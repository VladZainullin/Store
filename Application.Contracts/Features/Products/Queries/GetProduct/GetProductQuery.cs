using MediatR;

namespace Application.Contracts.Features.Products.Queries.GetProduct;

public sealed record GetProductQuery(GetProductRequestRouteDto RouteDto) : IRequest<GetProductResponseDto>;