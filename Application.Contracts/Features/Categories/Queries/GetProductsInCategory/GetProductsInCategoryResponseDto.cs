namespace Application.Contracts.Features.Categories.Queries.GetProductsInCategory;

public sealed class GetProductsInCategoryResponseDto
{
    public required IEnumerable<ProductDto> Products { get; init; }

    public sealed class ProductDto
    {
        public required Guid ProductId { get; init; }

        public required string Title { get; init; }

        public required decimal Cost { get; init; }

        public required int Quantity { get; init; }
    }
}