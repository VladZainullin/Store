namespace Application.Contracts.Features.Carts.Commands.AddProductToCart;

public sealed class AddProductToCartRequestBodyDto
{
    public required int Quantity { get; init; }
}