using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Queries.GetCategoryLogo;

public sealed record GetCategoryLogoQuery(GetCategoryLogoRequestRouteDto RouteDto) : IRequest<GetCategoryLogoResponseDto>;