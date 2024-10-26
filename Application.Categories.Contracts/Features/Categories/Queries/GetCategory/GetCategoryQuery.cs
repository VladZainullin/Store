using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Queries.GetCategory;

public sealed record GetCategoryQuery(GetCategoryRequestRouteDto RouteDto) : IRequest<GetCategoryResponseDto>;