using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Exceptions;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<AddProductToCategoryCommand, AddProductToCategoryResponseDto>
{
    public async Task<AddProductToCategoryResponseDto> Handle(
        AddProductToCategoryCommand request,
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
            .SingleOrDefaultAsync(c => c.Id == request.Route.CategoryId, cancellationToken);

        if (ReferenceEquals(category, default))
        {
            throw new CategoryNotFoundException();
        }
        
        var productInCategoryId = category.AddProduct(new AddProductToCategoryParameters
        {
            Product = product,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);

        return new AddProductToCategoryResponseDto
        {
            ProductInCategoryId = productInCategoryId
        };
    }
}