using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using Application.Exceptions;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.RemoveCategory;

internal sealed class RemoveCategoryHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<RemoveCategoryCommand>
{
    public async ValueTask Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await GetCategoryAsync(request.Route.CategoryId, cancellationToken);
        if (ReferenceEquals(category, default))
        {
            throw new CategoryNotFoundException();
        }

        category.Remove(new RemoveCategoryParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Category?> GetCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return context.Categories
            .AsTracking()
            .Include(static c => c.Products)
            .SingleOrDefaultAsync(c => c.Id == categoryId, cancellationToken);
    }
}