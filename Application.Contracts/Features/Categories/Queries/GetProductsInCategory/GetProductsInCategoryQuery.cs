using MediatR;

namespace Application.Contracts.Features.Categories.Queries.GetProductsInCategory;

public sealed record GetProductsInCategoryQuery(
    GetProductsInCategoryRequestRouteDto Route,
    GetProductsInCategoryRequestQueryDto Query) : IRequest<GetProductsInCategoryResponseDto>;