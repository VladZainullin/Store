using Application.Contracts.Features.Categories.Commands.UpdateProduct;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.UpdateProduct;

internal sealed class UpdateProductHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);

        category.SetProductTitle(new SetCategoryProductTitleParameters
        {
            ProductId = request.RouteDto.ProductId,
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });
        
        category.SetProductDescriptionTitle(new SetCategoryProductDescriptionParameters
        {
            ProductId = request.RouteDto.ProductId,
            Description = request.BodyDto.Description,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}