using Application.Contracts.Features.Commands.CreateProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.CreateProduct;

internal sealed class CreateProductHandler(IDbContext context, TimeProvider timeProvider, IMinioClient minioClient)
    : IRequestHandler<CreateProductCommand, CreateProductResponseDto>
{
    public async Task<CreateProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createProductParameters = new CreateProductParameters
        {
            Title = request.FormDto.Title,
            Description = request.FormDto.Description,
            Quantity = request.FormDto.Quantity,
            Cost = request.FormDto.Cost,
            TimeProvider = timeProvider
        };

        var product = new Product(createProductParameters);
        
        context.Products.Add(product);
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
            .WithObject(product.Photo.ToString())
            .WithObjectSize(request.FormDto.Photo.Length)
            .WithStreamData(request.FormDto.Photo.OpenReadStream());
        await minioClient.PutObjectAsync(putObjectArgs, cancellationToken);
        
        return new CreateProductResponseDto
        {
            ProductId = product.Id
        };
    }
}