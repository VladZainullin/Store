using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Domain.Entities.Carts;
using Domain.Entities.Carts.Parameters;
using Domain.Entities.Products;
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
        var cart = await GetCartAsync(request.RouteDto.CartId, cancellationToken);
        if (ReferenceEquals(cart, default)) return;
        
        var product = await GetProductAsync(request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        cart.AddProduct(new AddProductToCartParameters
        {
            Product = product,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Cart?> GetCartAsync(Guid cartId, CancellationToken cancellationToken)
    {
        return context.Carts
            .AsTracking()
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == cartId, cancellationToken);
    }

    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }
}