using Application.Contracts.Features.Categories.Commands.AddPhotoToProduct;
using Domain.Categories.Entities.Categories.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;
using Persistence.Contracts.DbSets.Categories.Queries;

namespace Application.Features.Categories.Commands.AddPhotoToProduct;

internal sealed class AddPhotoToProductHandler(
    IDbContext context,
    IMinioClient minioClient,
    TimeProvider timeProvider) : IRequestHandler<AddPhotoToProductCommand, AddPhotoToProductResponseDto>
{
    public async Task<AddPhotoToProductResponseDto> Handle(AddPhotoToProductCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.GetAsync(new GetCategoryByIdInputData
        {
            CategoryId = request.RequestRouteDto.CategoryId,
            AsTracking = true,
            IncludeProducts = true
        }, cancellationToken);

        var newPhotoId = Guid.NewGuid();
        
        category.AddPhotoToProduct(new AddPhotoToCategoryProductParameters
        {
            ProductId = request.RequestRouteDto.ProductId,
            Photo = newPhotoId,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);

        var bucketExistsArgs = new BucketExistsArgs()
            .WithBucket("product_photos");
        var bucketExists = await minioClient.BucketExistsAsync(bucketExistsArgs, cancellationToken);
        if (!bucketExists)
        {
            var makeBucketArgs = new MakeBucketArgs()
                .WithBucket("product_photos");

            await minioClient.MakeBucketAsync(makeBucketArgs, cancellationToken);
        }

        var putObjectArgs = new PutObjectArgs()
            .WithBucket("categories")
            .WithObject(category.LogoId.ToString())
            .WithObjectSize(request.RequestFormDto.Photo.Length)
            .WithStreamData(request.RequestFormDto.Photo.OpenReadStream());
        await minioClient.PutObjectAsync(putObjectArgs, cancellationToken);

        return new AddPhotoToProductResponseDto
        {
            Photo = newPhotoId
        };
    }
}