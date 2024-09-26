using Application.Contracts.Features.Vodkas.Commands.CreateVodka;
using Domain.Entities;
using Domain.Entities.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Vodkas.Commands.CreateVodka;

file sealed class CreateVodkaHandler(IDbContext context) : IRequestHandler<CreateVodkaCommand, CreateVodkaResponseDto>
{
    public async Task<CreateVodkaResponseDto> Handle(CreateVodkaCommand request, CancellationToken cancellationToken)
    {
        var oldVodka = await GetVodkaAsync(request.BodyDto.Title, cancellationToken);
        if (!ReferenceEquals(oldVodka, default))
            return new CreateVodkaResponseDto
            {
                VodkaId = oldVodka.Id
            };
        
        var parameters = new CreateVodkaParameters
        {
            Title = request.BodyDto.Title,
            Description = request.BodyDto.Description
        };
        var vodka = new Vodka(parameters);
            
        context.Vodkas.Add(vodka);
        await context.SaveChangesAsync(cancellationToken);
            
        return new CreateVodkaResponseDto
        {
            VodkaId = vodka.Id
        };

    }
    
    private Task<Vodka?> GetVodkaAsync(string manufacturerTitle, CancellationToken cancellationToken)
    {
        return context.Vodkas
            .AsTracking()
            .SingleOrDefaultAsync(m => m.Title == manufacturerTitle, cancellationToken);
    }
}