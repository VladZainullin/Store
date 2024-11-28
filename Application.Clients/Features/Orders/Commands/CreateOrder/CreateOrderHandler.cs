using Application.Contracts.Features.Orders.Commands.CreateOrder;
using Application.Exceptions;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Orders.Commands.CreateOrder;

internal sealed class CreateOrderHandler(
    IDbContext context,
    TimeProvider timeProvider,
    ICurrentClient<Guid> currentClient) : 
    IRequestHandler<CreateOrderCommand, CreateOrderResponseDto>
{
    public async Task<CreateOrderResponseDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .AsTracking()
            .Include(c => c.Products)
            .SingleOrDefaultAsync(c => c.ClientId == currentClient.ClientId, cancellationToken);

        if (ReferenceEquals(cart, default))
        {
            throw new CartNotFoundException();
        }
        
        var order = cart.CreateOrder(new CreateOrderFromCartParameters
        {
            TimeProvider = timeProvider
        });
        
        context.Orders.Add(order);

        await context.SaveChangesAsync(cancellationToken);

        return new CreateOrderResponseDto
        {
            OrderId = order.Id
        };
    }
}