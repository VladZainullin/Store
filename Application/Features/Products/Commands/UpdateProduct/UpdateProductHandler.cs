using Application.Contracts.Features.Commands.UpdateProduct;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
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