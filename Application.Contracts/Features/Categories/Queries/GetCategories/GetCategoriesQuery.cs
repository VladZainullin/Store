using Mediator;

namespace Application.Contracts.Features.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery(GetCategoriesRequestQueryDto QueryDto) : IRequest<GetCategoriesResponseDto>;