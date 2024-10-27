using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Queries.GetProduct;

public sealed record GetProductQuery(GetProductRequestRouteDto RouteDto) : IRequest<GetProductResponseDto>;