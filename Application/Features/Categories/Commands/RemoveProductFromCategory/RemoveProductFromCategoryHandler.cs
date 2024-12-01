using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Application.Exceptions;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.RemoveProductFromCategory;

public sealed class RemoveProductFromCategoryHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<RemoveProductFromCategoryCommand>
{
    public async Task Handle(
        RemoveProductFromCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        var category = await context.Categories
            .AsTracking()
            .Include(p => p.Products)
            .SingleOrDefaultAsync(c => c.Id == request.Route.CategoryId, cancellationToken);

        if (ReferenceEquals(category, default))
        {
            throw new CategoryNotFoundException();
        }
        
        category.RemoveProduct(new RemoveProductFromCategoryParameters
        {
            Product = product,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}