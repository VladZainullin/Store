namespace Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;

public sealed record RemoveProductFromCartRequestBodyDto
{
    public required int Quantity { get; init; }
}