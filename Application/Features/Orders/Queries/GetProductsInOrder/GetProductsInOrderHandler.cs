using Application.Contracts.Features.Orders.Queries.GetProductsInOrder;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Orders.Queries.GetProductsInOrder;

internal sealed class GetProductsInOrderHandler(IDbContext context) : 
    IRequestHandler<GetProductsInOrderQuery, GetProductsInOrderResponseDto>
{
    public async ValueTask<GetProductsInOrderResponseDto> Handle(
        GetProductsInOrderQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.ProductInOrders
            .AsNoTracking()
            .Where(pic => pic.Order.Id == request.Route.OrderId);

        if (request.Query.Skip > 0)
        {
            queryable = queryable.Skip(request.Query.Skip);
        }

        if (request.Query.Take > 0)
        {
            queryable = queryable.Take(request.Query.Take);
        }

        return new GetProductsInOrderResponseDto
        {
            Products = await queryable
                .Select(static pic => new GetProductsInOrderResponseDto.ProductDto
                {
                    ProductId = pic.Product.Id,
                    Title = pic.Product.Title,
                    Cost = pic.Cost,
                    Quantity = pic.Quantity
                })
                .ToListAsync(cancellationToken)
        };
    }
}