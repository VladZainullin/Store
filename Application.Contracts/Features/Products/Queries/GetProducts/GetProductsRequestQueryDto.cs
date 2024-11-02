namespace Application.Contracts.Features.Products.Queries.GetProducts;

public sealed class GetProductsRequestQueryDto
{
    public required DateTimeOffset? GreaterThat { get; init; }

    public required int Take { get; init; }

    public required Guid? CategoryId { get; init; }
}