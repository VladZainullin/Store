using Application.Contracts.Features.Characteristics.Commands.RemoveCharacteristic;
using Application.Exceptions;
using Domain.Entities.Characteristics.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Characteristics.Commands.RemoveCharacteristic;

internal sealed class RemoveCharacteristicHandler(
    IDbContext context,
    TimeProvider timeProvider) : 
    IRequestHandler<RemoveCharacteristicCommand>
{
    public async Task Handle(
        RemoveCharacteristicCommand request,
        CancellationToken cancellationToken)
    {
        var characteristic = await context.Characteristics
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Route.CharacteristicId, cancellationToken);

        if (ReferenceEquals(characteristic, default))
        {
            throw new CharacteristicNotFoundException();
        }
        
        characteristic.Remove(new RemoveCharacteristicParameters
        {
            TimeProvider = timeProvider
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }
}