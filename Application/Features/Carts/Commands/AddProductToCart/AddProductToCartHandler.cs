using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Carts.Commands.AddProductToCart;

internal sealed class AddProductToCartHandler(
    IDbContext context,
    TimeProvider timeProvider) : 
    IRequestHandler<AddProductToCartCommand>
{
    public async Task Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .AsTracking()
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CartId, cancellationToken);
        
        if (ReferenceEquals(cart, default)) return;
        
        cart.AddProduct(new AddProductToCartParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}