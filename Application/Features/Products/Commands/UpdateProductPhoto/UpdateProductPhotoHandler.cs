using Application.Contracts.Features.Commands.UpdateProductPhoto;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.UpdateProductPhoto;

internal sealed class UpdateProductPhotoHandler(IDbContext context, IMinioClient minioClient, TimeProvider timeProvider)
    : IRequestHandler<UpdateProductPhotoCommand>
{
    public async Task Handle(UpdateProductPhotoCommand request, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        product.UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);

        const string productPhotosBucket = "product-photos";
        var bucketExists = await minioClient.BucketExistsAsync(
            new BucketExistsArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        if (!bucketExists)
        {
            await minioClient.MakeBucketAsync(new MakeBucketArgs()
                .WithBucket(productPhotosBucket), cancellationToken);
        }

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(productPhotosBucket)
            .WithObject(product.Photo.ToString())
            .WithStreamData(request.FormDto.Photo.OpenReadStream()), cancellationToken);
    }
}