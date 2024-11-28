namespace Application.Contracts.Features.Carts.Queries.GetProductsInCart;

public sealed class GetProductsInCartQueryDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}