using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery(GetCategoriesRequestQueryDto QueryDto) : IRequest<GetCategoriesResponseDto>;