using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<AddProductToCategoryCommand>
{
    public async Task Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);
        
        category.AddProduct(new AddProductToCategoryParameters
        {
            Product = new AddProductToCategoryParameters.ProductParameter
            {
                Title = request.BodyDto.Title,
                Description = request.BodyDto.Title
            },
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}