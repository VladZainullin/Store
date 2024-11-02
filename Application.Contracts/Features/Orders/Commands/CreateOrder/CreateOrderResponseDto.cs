namespace Application.Contracts.Features.Orders.Commands.CreateOrder;

public sealed class CreateOrderResponseDto
{
    public required Guid OrderId { get; init; }
}