namespace Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;

public sealed record RemoveProductFromCartRequestRouteDto
{
    public required Guid ProductId { get; init; }
}