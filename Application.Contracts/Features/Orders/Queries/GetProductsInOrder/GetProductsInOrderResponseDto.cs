namespace Application.Contracts.Features.Orders.Queries.GetProductsInOrder;

public sealed class GetProductsInOrderResponseDto
{
    public required IEnumerable<ProductDto> Products { get; init; }

    public sealed class ProductDto
    {
        public required Guid ProductId { get; init; }

        public required string Title { get; init; }

        public required decimal Cost { get; init; }

        public required decimal Quantity { get; set; }
    }
}