using Application.Contracts.Features.Categories.Queries.GetProductsInCategory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Queries.GetProductsInCategory;

internal sealed class GetProductsInCategoryHandler(IDbContext context) : 
    IRequestHandler<GetProductsInCategoryQuery, GetProductsInCategoryResponseDto>
{
    public async Task<GetProductsInCategoryResponseDto> Handle(
        GetProductsInCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.ProductInCategories
            .AsNoTracking()
            .Where(pic => pic.Category.Id == request.Route.CategoryId)
            .Select(pic => pic.Product);

        if (request.Query.Skip > 0)
        {
            queryable = queryable.Skip(request.Query.Skip);
        }

        if (request.Query.Take > 0)
        {
            queryable = queryable.Take(request.Query.Take);
        }

        return new GetProductsInCategoryResponseDto
        {
            Products = await queryable
                .Select(static p => new GetProductsInCategoryResponseDto.ProductDto
                {
                    ProductId = p.Id,
                    Title = p.Title,
                    Cost = p.Cost,
                    Quantity = p.Quantity
                })
                .ToListAsync(cancellationToken)
        };
    }
}