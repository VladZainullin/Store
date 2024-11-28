namespace Application.Contracts.Features.Orders.Commands.CreateOrder;

public sealed class CreateOrderRequestBodyDto
{
    public required string Street { get; init; }
    
    public required string House { get; init; }
    
    public required string? Comment { get; init; }
}