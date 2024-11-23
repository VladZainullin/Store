using Application.Contracts.Features.Orders.Queries.GetOrders;
using Clients.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Orders.Queries.GetOrders;

internal sealed class GetOrdersHandler(IDbContext context, ICurrentClient<Guid> currentClient) : 
    IRequestHandler<GetOrdersQuery, GetOrdersResponseDto>
{
    public async Task<GetOrdersResponseDto> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = context.Orders
            .AsNoTracking();

        if (request.Query.Skip is > 0)
        {
            queryable = queryable.Skip(request.Query.Skip.Value);
        }
        
        if (request.Query.Take is > 0)
        {
            queryable = queryable.Take(request.Query.Take.Value);
        }

        queryable = queryable
            .Where(o => o.ClientId == currentClient.ClientId)
            .OrderByDescending(static o => o.CreatedAt);
        
        return new GetOrdersResponseDto
        {
            Orders = await queryable
                .Select(static o => new GetOrdersResponseDto.OrderDto
                {
                    CreatedAt = o.CreatedAt,
                    Cost = o.Products.Sum(static p => p.Cost * p.Quantity)
                })
                .ToListAsync(cancellationToken)
        };
    }
}