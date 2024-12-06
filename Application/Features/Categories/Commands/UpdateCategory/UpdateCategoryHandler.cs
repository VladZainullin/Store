using Application.Contracts.Features.Categories.Commands.UpdateCategory;
using Domain.Entities.Categories.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.UpdateCategory;

internal sealed class UpdateCategoryHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<UpdateCategoryCommand>
{
    public async ValueTask Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CategoryId, cancellationToken);
        if (ReferenceEquals(category, default)) return;
        
        category.SetTitle(new SetCategoryTitleParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}