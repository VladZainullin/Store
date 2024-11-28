namespace Application.Contracts.Features.Orders.Queries.GetOrders;

public sealed class GetOrdersResponseDto
{
    public required IEnumerable<OrderDto> Orders { get; init; }
    
    public sealed class OrderDto
    {
        public required DateTimeOffset CreatedAt { get; init; }

        public required decimal Cost { get; init; }
    }
}