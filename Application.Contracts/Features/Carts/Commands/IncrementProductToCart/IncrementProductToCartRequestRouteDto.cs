// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Carts.Commands.IncrementProductToCart;

public sealed class IncrementProductToCartRequestRouteDto
{
    public required Guid CartId { get; init; }
    
    public required Guid ProductId { get; init; }
}