using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Domain.Categories.Entities.Categories;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Categories.Commands.CreateCategory;

internal sealed class CreateCategoryHandler(
    IDbContext context,
    TimeProvider timeProvider,
    IMinioClient minioClient) :
    IRequestHandler<CreateCategoryCommand, CreateCategoryResponseDto>
{
    public async Task<CreateCategoryResponseDto> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var p = new PutObjectArgs()
            .WithBucket("categories")
            .WithObject(request.FormDto.File.FileName)
            .WithObjectSize(request.FormDto.File.Length)
            .WithStreamData(request.FormDto.File.OpenReadStream());
        
        await minioClient.PutObjectAsync(p, cancellationToken);
        
        var category = new Category(new CreateCategoryParameters
        {
            Title = request.FormDto.Title,
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