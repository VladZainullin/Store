using Application.Contracts.Features.Characteristics.Commands.UpdateCharacteristic;
using Application.Exceptions;
using Domain.Entities.Characteristics.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Characteristics.Commands.UpdateCharacteristic;

internal sealed class UpdateCharacteristicHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<UpdateCharacteristicCommand>
{
    public async ValueTask Handle(UpdateCharacteristicCommand request, CancellationToken cancellationToken)
    {
        var characteristic = await context.Characteristics
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Route.CharacteristicId, cancellationToken);

        if (ReferenceEquals(characteristic, default))
        {
            throw new CharacteristicNotFoundException();
        }
        
        characteristic.SetTitle(new SetTitleForCharacteristicParameters
        {
            Title = request.Body.Title,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}