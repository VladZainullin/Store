namespace Application.Contracts.Features.Carts.Commands.AddProductToCart;

public sealed class AddProductToCartRequestRouteDto
{
    public required Guid CartId { get; init; }
    
    public required Guid ProductId { get; init; }
}