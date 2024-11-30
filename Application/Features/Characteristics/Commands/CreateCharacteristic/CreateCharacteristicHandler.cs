using Application.Contracts.Features.Characteristics.Commands.CreateCharacteristic;
using Domain.Entities.Characteristics;
using Domain.Entities.Characteristics.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Characteristics.Commands.CreateCharacteristic;

internal sealed class CreateCharacteristicHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<CreateCharacteristicCommand, CreateCharacteristicResponseDto>
{
    public async Task<CreateCharacteristicResponseDto> Handle(
        CreateCharacteristicCommand request,
        CancellationToken cancellationToken)
    {
        var characteristic = await context.Characteristics
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Title == request.Body.Title, cancellationToken);

        if (!ReferenceEquals(characteristic, default))
        {
            if (characteristic.IsRemoved)
            {
                characteristic.Restore(new RestoreCharacteristicParameters
                {
                    TimeProvider = timeProvider
                });
            }

            return new CreateCharacteristicResponseDto
            {
                CharacteristicId = characteristic.Id
            };
        }

        var newCharacteristic = new Characteristic(new CreateCharacteristicParameters
        {
            Title = request.Body.Title,
            TimeProvider = timeProvider,
        });

        context.Characteristics.Add(newCharacteristic);
        
        await context.SaveChangesAsync(cancellationToken);

        return new CreateCharacteristicResponseDto
        {
            CharacteristicId = newCharacteristic.Id
        };
    }
}