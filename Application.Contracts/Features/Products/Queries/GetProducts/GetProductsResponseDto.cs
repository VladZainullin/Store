namespace Application.Contracts.Features.Products.Queries.GetProducts;

public sealed class GetProductsResponseDto
{
    public required IEnumerable<ProductDto> Products { get; init; }
    
    public sealed class ProductDto
    {
        public required Guid ProductId { get; init; }

        public required string Title { get; init; }

        public required decimal Cost { get; init; }

        public required int InCart { get; init; }
    }
}