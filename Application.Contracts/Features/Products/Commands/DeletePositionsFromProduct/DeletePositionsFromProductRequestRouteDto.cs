namespace Application.Contracts.Features.Products.Commands.DeletePositionsFromProduct;

public sealed class DeletePositionsFromProductRequestRouteDto
{
    public required Guid ProductId { get; init; }
}