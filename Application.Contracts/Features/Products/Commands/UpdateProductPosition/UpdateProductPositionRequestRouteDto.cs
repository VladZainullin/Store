namespace Application.Contracts.Features.Products.Commands.UpdateProductPosition;

public sealed class UpdateProductPositionRequestRouteDto
{
    public required Guid ProductId { get; init; }

    public required Guid PositionId { get; init; }
}