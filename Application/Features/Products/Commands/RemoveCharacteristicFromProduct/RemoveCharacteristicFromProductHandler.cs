using Application.Contracts.Features.Products.Commands.RemoveCharacteristicFromProduct;
using Application.Exceptions;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.RemoveCharacteristicFromProduct;

internal sealed class RemoveCharacteristicFromProductHandler(IDbContext context, TimeProvider timeProvider)
    : IRequestHandler<RemoveCharacteristicFromProductCommand>
{
    public async Task Handle(
        RemoveCharacteristicFromProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        product.RemoveCharacteristic(new RemoveCharacteristicForProductParameters
        {
            TimeProvider = timeProvider,
            CharacteristicId = request.Route.CharacteristicId
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }
}