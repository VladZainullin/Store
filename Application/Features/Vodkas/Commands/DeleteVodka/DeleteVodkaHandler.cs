using Application.Contracts.Features.Vodkas.Commands.DeleteVodka;
using Domain.Entities;
using Domain.Entities.Vodkas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Vodkas.Commands.DeleteVodka;

file sealed class DeleteVodkaHandler(IDbContext context) : IRequestHandler<DeleteVodkaCommand>
{
    public async Task Handle(DeleteVodkaCommand request, CancellationToken cancellationToken)
    {
        var vodka = await GetVodkaAsync(request.RouteDto.VodkaId, cancellationToken);
        if (ReferenceEquals(vodka, default)) return;

        context.Vodkas.Remove(vodka);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<Vodka?> GetVodkaAsync(Guid vodkaId, CancellationToken cancellationToken)
    {
        return context.Vodkas
            .AsTracking()
            .Where(m => m.Id == vodkaId)
            .SingleOrDefaultAsync(cancellationToken);
    }
}