using Application.Contracts.Features.Products.Commands.AddCharacteristicToProduct;
using Application.Exceptions;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.AddCharacteristicToProduct;

internal sealed class AddCharacteristicToProductHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<AddCharacteristicToProductCommand>
{
    public async Task Handle(
        AddCharacteristicToProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        var characteristic = await context.Characteristics
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Body.CharacteristicId, cancellationToken);

        if (ReferenceEquals(characteristic, default))
        {
            throw new CharacteristicNotFoundException();
        }
        
        product.AddCharacteristic(new AddCharacteristicForProductParameters
        {
            Characteristic = characteristic,
            TimeProvider = timeProvider,
            Value = request.Body.Value
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }
}