using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.RemoveCategory;

internal sealed class RemoveCategoryHandler(IDbContext context) : IRequestHandler<RemoveCategoryCommand>
{
    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CategoryId, cancellationToken);
        if (ReferenceEquals(category, default)) return;
        
        context.Categories.Remove(category);

        await context.SaveChangesAsync(cancellationToken);
    }
}