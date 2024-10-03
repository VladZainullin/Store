using Application.Contracts.Features.Products.Commands.DeleteProduct;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.DeleteProduct;

file sealed class DeleteProductHandler(IDbContext context) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsync(request.RequestRouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;

        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .Where(m => m.Id == productId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}