using Application.Contracts.Features.Products.Queries.GetProduct;
using Clients.Contracts;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Queries.GetProduct;

public sealed class GetProductHandler(IDbContext context, ICurrentClient<Guid> currentClient) : 
    IRequestHandler<GetProductQuery, GetProductResponseDto>
{
    public async ValueTask<GetProductResponseDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsNoTracking()
            .Where(p => p.Id == request.RouteDto.ProductId)
            .Select(static p => new GetProductResponseDto
            {
                ProductId = p.Id,
                Title = p.Title,
                Description = p.Description,
                InCart = 0,
                InWarehouse = p.Quantity
            })
            .SingleAsync(cancellationToken);

        var productInCartQuantity = await context.Carts
            .AsNoTracking()
            .Where(c => c.ClientId == currentClient.ClientId)
            .SelectMany(static c => c.Products)
            .Where(p => p.Id == request.RouteDto.ProductId)
            .Select(p => p.Quantity)
            .SingleOrDefaultAsync(cancellationToken);

        if (productInCartQuantity != default)
        {
            return product with
            {
                InCart = productInCartQuantity,
            };
        }

        return product;
    }
}