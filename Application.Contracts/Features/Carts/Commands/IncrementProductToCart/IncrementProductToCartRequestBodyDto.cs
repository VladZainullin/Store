namespace Application.Contracts.Features.Carts.Commands.IncrementProductToCart;

public sealed class IncrementProductToCartRequestBodyDto
{
    public required int Quantity { get; init; }
}