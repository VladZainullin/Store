using Application.Contracts.Features.Orders.Commands.CancelOrder;
using Application.Exceptions;
using Domain.Entities.Orders.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Orders.Commands.CancelOrder;

internal sealed class CancelOrderHandler(
    IDbContext context,
    TimeProvider timeProvider) : Abstractions.IRequestHandler<CancelOrderCommand>
{
    public async ValueTask Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .AsTracking()
            .Include(o => o.Products)
            .SingleOrDefaultAsync(o => o.Id == request.Route.OrderId, cancellationToken);

        if (ReferenceEquals(order, default))
        {
            throw new OrderNotFoundException();
        }
        
        order.Cancel(new CancelOrderParameters
        {
            TimeProvider = timeProvider
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }
}