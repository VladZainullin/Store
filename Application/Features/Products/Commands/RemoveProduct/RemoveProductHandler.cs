using Application.Contracts.Features.Products.Commands.RemoveProduct;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.RemoveProduct;

internal sealed class RemoveProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<RemoveProductCommand>
{
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        product.Remove(new RemoveProductParameters
        {
            TimeProvider = timeProvider
        });
        await context.SaveChangesAsync(cancellationToken);
    }
}