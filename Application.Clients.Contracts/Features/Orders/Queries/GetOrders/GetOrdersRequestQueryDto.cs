namespace Application.Contracts.Features.Orders.Queries.GetOrders;

public sealed class GetOrdersRequestQueryDto
{
    public required int? Skip { get; init; }

    public required int? Take { get; init; }
}