using Application.Contracts.Features.Carts.Queries.GetProductsInCart;
using Clients.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Carts.Queries.GetProductsInCart;

internal sealed class GetProductsInCartHandler(IDbContext context, ICurrentClient<Guid> currentClient) :
    IRequestHandler<GetProductsInCartQuery, GetProductsInCartResponseDto>
{
    public async Task<GetProductsInCartResponseDto> Handle(
        GetProductsInCartQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.ProductInCarts
            .Where(pic => pic.Cart.ClientId == currentClient.ClientId && !pic.IsRemoved);

        if (request.Query.Skip > 0)
        {
            queryable = queryable.Skip(request.Query.Skip);
        }

        if (request.Query.Take > 0)
        {
            queryable = queryable.Take(request.Query.Take);
        }

        queryable = queryable.OrderByDescending(static pic => pic.CreatedAt);

        return new GetProductsInCartResponseDto
        {
            Products = await queryable
                .Select(static pic => new GetProductsInCartResponseDto.ProductDto
                {
                    ProductId = pic.Product.Id,
                    Title = pic.Product.Title,
                    Quantity = pic.Quantity,
                    Cost = pic.Product.Cost
                })
                .ToListAsync(cancellationToken)
        };
    }
}