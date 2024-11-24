using Application.Contracts.Features.Orders.Queries.GetProductsInOrder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Orders.Queries.GetProductsInOrder;

internal sealed class GetProductsInOrderHandler(IDbContext context) : 
    IRequestHandler<GetProductsInOrderQuery, GetProductsInOrderResponseDto>
{
    public async Task<GetProductsInOrderResponseDto> Handle(
        GetProductsInOrderQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.ProductInOrders
            .AsNoTracking()
            .Where(p => p.Order.Id == request.Route.OrderId)
            .Select(p => p.Product);

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
                .Select(static p => new GetProductsInOrderResponseDto.ProductDto
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