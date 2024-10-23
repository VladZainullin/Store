using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.AddProductToCategory;

public sealed class AddProductToCategoryHandler(
    IDbContext context,
    IMinioClient minioClient,
    TimeProvider timeProvider) : IRequestHandler<AddProductToCategoryCommand, AddProductToCategoryResponseDto>
{
    public async Task<AddProductToCategoryResponseDto> Handle(AddProductToCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);

        var productParameter = new AddProductToCategoryParameters.ProductParameter
        {
            Title = request.FormDto.Title,
            Description = request.FormDto.Title
        };
        category.AddProduct(new AddProductToCategoryParameters
        {
            Product = productParameter,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);

        var bucketExistsArgs = new BucketExistsArgs().WithBucket("product-photos");
        var exists = await minioClient.BucketExistsAsync(bucketExistsArgs, cancellationToken);
        if (!exists)
        {
            var makeBucketArgs = new MakeBucketArgs()
                .WithBucket("product-photos");
            await minioClient.MakeBucketAsync(makeBucketArgs, cancellationToken);
        }

        var putObjectArgs = new PutObjectArgs()
            .WithBucket("product-photos")
            .WithObject(productParameter.Photo.ToString())
            .WithObjectSize(request.FormDto.Photo.Length)
            .WithStreamData(request.FormDto.Photo.OpenReadStream());
        await minioClient.PutObjectAsync(putObjectArgs, cancellationToken);

        return new AddProductToCategoryResponseDto
        {
            Photo = productParameter.Photo
        };
    }
}