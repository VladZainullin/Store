using Application.Contracts.Features.Categories.Commands.RestoreProductFromCategory;
using Application.Exceptions;
using Domain.Entities.ProductInCategories.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.RestoreProductFromCategory;

internal sealed class RestoreProductFromCategoryHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<RestoreProductFromCategoryCommand>
{
    public async Task Handle(
        RestoreProductFromCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var productInCategory = await context.ProductInCategories
            .AsTracking()
            .Include(static pic => pic.Category)
            .Include(static pic => pic.Product)
            .SingleOrDefaultAsync(pic =>
                pic.Category.Id == request.Route.CategoryId
                && pic.Product.Id == request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(productInCategory, default))
        {
            throw new ProductInCategoryNotFoundException();
        }
        
        productInCategory.Restore(new RestoreProductInCategoryParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}