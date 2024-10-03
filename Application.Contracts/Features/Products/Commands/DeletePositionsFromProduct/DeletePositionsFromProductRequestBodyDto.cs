namespace Application.Contracts.Features.Products.Commands.DeletePositionsFromProduct;

public sealed class DeletePositionsFromProductRequestBodyDto
{
    public required IEnumerable<Guid> PositionIds { get; init; }
}