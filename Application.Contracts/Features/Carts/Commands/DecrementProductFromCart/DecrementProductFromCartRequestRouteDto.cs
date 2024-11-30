// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Carts.Commands.DecrementProductFromCart;

public sealed record DecrementProductFromCartRequestRouteDto
{
    public required Guid ProductId { get; init; }
}