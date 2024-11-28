using Application.Contracts.Features.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Queries.GetCategories;

internal sealed class GetCategoriesHandler(IDbContext context) :
    IRequestHandler<GetCategoriesQuery, GetCategoriesResponseDto>
{
    public async Task<GetCategoriesResponseDto> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.Categories.AsNoTracking();

        if (request.QueryDto.Skip > 0)
        {
            var queryDtoSkip = request.QueryDto.Skip;
            queryable = queryable.Skip(queryDtoSkip);
        }

        if (request.QueryDto.Take > 0)
        {
            queryable = queryable.Take(request.QueryDto.Take);
        }

        queryable = queryable.OrderBy(static c => c.Title);
        
        var categories = await queryable
            .Select(static c => new GetCategoriesResponseDto.CategoryDto
            {
                Id = c.Id,
                Title = c.Title
            })
            .ToListAsync(cancellationToken);

        return new GetCategoriesResponseDto
        {
            Categories = categories
        };
    }
}