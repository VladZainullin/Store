using Application.Contracts.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsHandler(IDbContext context) :
    IRequestHandler<GetProductsQuery, GetProductsResponseDto>
{
    public async Task<GetProductsResponseDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var queryable = context.Products.AsQueryable();

        if (request.QueryDto.CategoryId.HasValue)
        {
            queryable = queryable.Where(p => p.CategoryId == request.QueryDto.CategoryId);
        }
        
        if (request.QueryDto.GreaterThat.HasValue)
        {
            queryable = queryable.Where(p => p.CreatedAt >= request.QueryDto.GreaterThat);
        }

        queryable = queryable.Take(request.QueryDto.Take);

        var products = await queryable
            .Select(static p => new GetProductsResponseDto.ProductDto
            {
                ProductId = p.Id,
                Title = p.Title,
                Cost = p.Cost,
                InCart = 1
            })
            .ToListAsync(cancellationToken);

        return new GetProductsResponseDto
        {
            Products = products
        };
    }
}