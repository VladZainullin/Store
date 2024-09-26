using Application.Contracts.Features.Vodkas.Commands.DeleteVodkas;
using Domain.Entities;
using Domain.Entities.Vodkas;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Vodkas.Commands.DeleteVodkas;

public sealed class DeleteVodkasHandler(IDbContext context) : IRequestHandler<DeleteVodkasCommand>
{
    public async Task Handle(DeleteVodkasCommand request, CancellationToken cancellationToken)
    {
        var vodkas = await GetVodkasAsync(request.BodyDto.VodkaIds, cancellationToken);
        
        context.Vodkas.RemoveRange(vodkas);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    private Task<List<Vodka>> GetVodkasAsync(
        IEnumerable<Guid> manufacturerIds,
        CancellationToken cancellationToken)
    {
        return context.Vodkas
            .AsTracking()
            .Where(m => manufacturerIds.Contains(m.Id))
            .ToListAsync(cancellationToken);
    }
}