using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.UpdateProduct;

file sealed class UpdateProductHandler(IDbContext context) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsync(request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;

        var setTitleParameters = new SetProductTitleParameters
        {
            Title = request.BodyDto.Title
        };
        product.SetTitle(setTitleParameters);

        var setDescriptionParameters = new SetProductDescriptionParameters
        {
            Description = request.BodyDto.Description
        };
        product.SetDescription(setDescriptionParameters);

        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Id == productId, cancellationToken);
    }
}