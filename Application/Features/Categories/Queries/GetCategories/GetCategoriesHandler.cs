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

        if (request.QueryDto.Skip != default)
        {
            queryable = queryable.Skip(request.QueryDto.Skip.Value);
        }

        if (request.QueryDto.Take != default)
        {
            queryable = queryable.Take(request.QueryDto.Take.Value);
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