using Application.Contracts.Features.Categories.Queries.GetProductsInCategory;
using Clients.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Queries.GetProductsInCategory;

internal sealed class GetProductsInCategoryHandler(IDbContext context, ICurrentClient<Guid> currentClient) :
    IRequestHandler<GetProductsInCategoryQuery, GetProductsInCategoryResponseDto>
{
    public async Task<GetProductsInCategoryResponseDto> Handle(
        GetProductsInCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.ProductInCategories
            .AsNoTracking()
            .Where(pic =>
                pic.Category.Id == request.Route.CategoryId
                && !pic.IsRemoved)
            .Select(static pic => pic.Product)
            .Where(static p => !p.IsRemoved);

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
                .Select(p => new GetProductsInCategoryResponseDto.ProductDto
                {
                    ProductId = p.Id,
                    Title = p.Title,
                    Cost = p.Cost,
                    QuantityInStock = p.Quantity,
                    QuantityInCart = p.ProductInCarts
                        .Where(pic => pic.Cart.ClientId == currentClient.ClientId)
                        .Sum(static pic => pic.Quantity)
                })
                .ToListAsync(cancellationToken)
        };
    }
}