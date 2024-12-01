// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Application.Contracts.Features.Orders.Queries.GetProductsInOrder;

public sealed class GetProductsInOrderRequestQueryDto
{
    public required int Skip { get; init; }

    public required int Take { get; init; }
}