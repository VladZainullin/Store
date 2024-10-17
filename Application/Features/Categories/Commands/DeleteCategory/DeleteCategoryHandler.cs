using Application.Contracts.Features.Categories.Commands.DeleteCategory;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.DeleteCategory;

internal sealed class DeleteCategoryHandler(IDbContext context) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        context.Categories.Remove(category);

        await context.SaveChangesAsync(cancellationToken);
    }
}