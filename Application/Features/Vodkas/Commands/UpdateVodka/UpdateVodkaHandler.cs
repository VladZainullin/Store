using Application.Contracts.Features.Vodkas.Commands.UpdateVodka;
using Domain.Entities;
using Domain.Entities.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Vodkas.Commands.UpdateVodka;

file sealed class UpdateVodkaHandler(IDbContext context) : IRequestHandler<UpdateVodkaCommand>
{
    public async Task Handle(UpdateVodkaCommand request, CancellationToken cancellationToken)
    {
        var vodka = await GetVodkaAsync(request.RouteDto.VodkaId, cancellationToken);
        if (ReferenceEquals(vodka, default)) return;

        var setTitleParameters = new SetVodkaTitleParameters
        {
            Title = request.BodyDto.Title
        };
        vodka.SetTitle(setTitleParameters);

        var setDescriptionParameters = new SetVodkaDescriptionParameters
        {
            Description = request.BodyDto.Description
        };
        vodka.SetDescription(setDescriptionParameters);

        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<Vodka?> GetVodkaAsync(Guid vodkaId, CancellationToken cancellationToken)
    {
        return context.Vodkas
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Id == vodkaId, cancellationToken);
    }
}