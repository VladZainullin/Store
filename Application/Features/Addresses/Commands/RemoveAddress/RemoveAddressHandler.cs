using Application.Contracts.Features.Addresses.Commands.RemoveAddress;
using Application.Exceptions;
using Clients.Contracts;
using Domain.Entities.Addresses.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Addresses.Commands.RemoveAddress;

internal sealed class RemoveAddressHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<RemoveAddressCommand>
{
    public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await context.Addresses
            .AsTracking()
            .SingleOrDefaultAsync(a => a.Id == request.Route.AddressId, cancellationToken);

        if (ReferenceEquals(address, default)) throw new AddressNotFoundException();
        
        address.Remove(new RemoveAddressParameters
        {
            TimeProvider = timeProvider
        });
    }
}