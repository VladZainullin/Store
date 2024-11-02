using Application.Contracts.Features.Commands.RemoveProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.RemoveProduct;

internal sealed class RemoveProductHandler(IDbContext context) : IRequestHandler<RemoveProductCommand>
{
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}