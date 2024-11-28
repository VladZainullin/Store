using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Domain.Entities.Categories;
using Domain.Entities.Categories.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(
    IDbContext context,
    TimeProvider timeProvider) :
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var oldCategory = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Title == request.BodyDto.Title, cancellationToken);
        
        if (!ReferenceEquals(oldCategory, default))
        {
            return new CreateCategoryResponseDto
            {
                CategoryId = oldCategory.Id
            };
        }
        
        var category = new Category(new CreateCategoryParameters
        {
            Title = request.BodyDto.Title,
            TimeProvider = timeProvider
        });

        context.Categories.Add(category);
        await context.SaveChangesAsync(cancellationToken);
        
        return new CreateCategoryResponseDto
        {
            CategoryId = category.Id
        };
    }
}