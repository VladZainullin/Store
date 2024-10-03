namespace Application.Contracts.Features.Products.Commands.DeleteProducts;

public sealed class DeleteProductsBodyDto
{
    public required IReadOnlyCollection<Guid> ProductIds { get; init; }
}