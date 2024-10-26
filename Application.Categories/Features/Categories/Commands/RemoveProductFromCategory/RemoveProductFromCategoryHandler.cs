using Application.Categories.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Categories.Features.Categories.Commands.RemoveProductFromCategory;

internal class RemoveProductFromCategoryHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<RemoveProductFromCategoryCommand>
{
    public async Task Handle(RemoveProductFromCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);

        var removableProduct = category.Products.SingleOrDefault(p => p.Id == request.RouteDto.ProductId);
        if (ReferenceEquals(removableProduct, default))
        {
            return;
        }
        
        category.RemoveProduct(new RemoveProductFromCategoryParameters
        {
            Product = removableProduct,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}