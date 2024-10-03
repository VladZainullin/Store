using Application.Contracts.Features.Products.Commands.DeleteProducts;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.DeleteProducts;

public sealed class DeleteProductHandler(IDbContext context) : IRequestHandler<DeleteProductsCommand>
{
    public async Task Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        var products = await GetProductsAsync(request.BodyDto.ProductIds, cancellationToken);
        
        context.Products.RemoveRange(products);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<List<Product>> GetProductsAsync(
        IEnumerable<Guid> productIds,
        CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .Where(m => productIds.Contains(m.Id))
            .ToListAsync(cancellationToken);
    }
}