using Application.Contracts.Features.Categories.Queries.GetCategoryLogoUploadUrl;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Categories.Queries.GetCategoryLogoUploadUrl;

internal sealed class GetCategoryLogoUploadUrlHandler(IMinioClient minioClient, IDbContext context) : 
    IRequestHandler<GetCategoryLogoUploadUrlQuery, GetCategoryLogoUploadUrlResponseDto>
{
    public async ValueTask<GetCategoryLogoUploadUrlResponseDto> Handle(GetCategoryLogoUploadUrlQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CategoryId, cancellationToken);
        if (ReferenceEquals(category, default))
        {
            throw new ArgumentOutOfRangeException(nameof(request.RouteDto.CategoryId), "Category not found");
        }
        
        var presignedUrl = await minioClient.PresignedPutObjectAsync(new PresignedPutObjectArgs()
            .WithObject(category.LogoId.ToString())
            .WithBucket("categories")
            .WithExpiry(60 * 60));

        return new GetCategoryLogoUploadUrlResponseDto
        {
            Url = presignedUrl
        };
    }
}