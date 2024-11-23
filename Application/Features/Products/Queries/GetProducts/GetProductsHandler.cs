using Application.Contracts.Features.Products.Queries.GetProducts;
using Clients.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Queries.GetProducts;

internal sealed class GetProductsHandler(IDbContext context, ICurrentClient<Guid> currentClient) :
    IRequestHandler<GetProductsQuery, GetProductsResponseDto>
{
    public async Task<GetProductsResponseDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var queryable = context.Products.AsNoTracking();
        
        if (request.QueryDto.Skip is > 0)
        {
            queryable = queryable.Skip(request.QueryDto.Skip.Value);
        }

        if (request.QueryDto.Take is > 0)
        {
            queryable = queryable.Take(request.QueryDto.Take.Value);
        }

        var products = await queryable
            .Select(static p => new GetProductsResponseDto.ProductDto
            {
                ProductId = p.Id,
                Title = p.Title,
                Cost = p.Cost,
                InCart = default
            })
            .ToListAsync(cancellationToken);
        
        var productInCartQuantities = await context.Carts
            .AsNoTracking()
            .Where(c => c.ClientId == currentClient.ClientId)
            .SelectMany(static c => c.Products)
            .ToDictionaryAsync(
                static c => c.Product.Id,
                static c => c.Quantity, cancellationToken);

        return new GetProductsResponseDto
        {
            Products = products.Select(p => p with
            {
                InCart = productInCartQuantities.GetValueOrDefault(p.ProductId)
            })
        };
    }
}