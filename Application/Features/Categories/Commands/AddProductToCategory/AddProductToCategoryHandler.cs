using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Exceptions;
using Domain.Entities.Categories.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<AddProductToCategoryCommand>
{
    public async ValueTask Handle(
        AddProductToCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Body.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        var category = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Route.CategoryId, cancellationToken);

        if (ReferenceEquals(category, default))
        {
            throw new CategoryNotFoundException();
        }
        
        category.AddProduct(new AddProductToCategoryParameters
        {
            Product = product,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}