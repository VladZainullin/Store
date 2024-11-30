using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using Domain.Entities.Categories.Parameters;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.RemoveCategory;

internal sealed class RemoveCategoryHandler(IDbContext context, TimeProvider timeProvider) :
    IRequestHandler<RemoveCategoryCommand>
{
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsTracking()
            .Include(static c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CategoryId, cancellationToken);
        
        if (ReferenceEquals(category, default)) return;

        category.Remove(new RemoveCategoryParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}