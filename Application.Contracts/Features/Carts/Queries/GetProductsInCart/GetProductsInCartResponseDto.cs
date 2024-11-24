namespace Application.Contracts.Features.Carts.Queries.GetProductsInCart;

public sealed class GetProductsInCartResponseDto
{
    public required IEnumerable<ProductDto> Products { get; init; }
    
    public sealed class ProductDto
    {
        public required Guid ProductId { get; init; }

        public required string Title { get; init; }

        public required int Quantity { get; init; }

        public required decimal Cost { get; init; }
    }
}