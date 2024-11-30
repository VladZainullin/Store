// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Carts.Commands.DecrementProductFromCart;

public sealed record DecrementProductFromCartRequestBodyDto
{
    public required int Quantity { get; init; }
}