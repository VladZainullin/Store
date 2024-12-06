using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Application.Exceptions;
using Domain.Entities.Products.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<UpdateProductCommand>
{
    public async ValueTask Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) throw new ProductNotFoundException();
        
        product.SetTitle(new SetProductTitleParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });
        
        product.SetDescription(new SetProductDescriptionParameters
        {
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        });
        
        product.SetCost(new SetProductCostParameters
        {
            Cost = request.BodyDto.Cost,
            TimeProvider = timeProvider
        });
        
        product.SetQuantity(new SetProductQuantityParameters
        {
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}