using Application.Contracts.Features.Categories.Queries.GetCategoryLogoGetUrl;

using Mediator;
using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel.Args;
using Persistence.Contracts;

namespace Application.Features.Categories.Queries.GetCategoryLogoGetUrl;

internal sealed class GetCategoryLogoGetUrl(
    IDbContext context,
    IMinioClient minioClient) : IRequestHandler<GetCategoryLogoGetUrlCommand, GetCategoryLogoGetUrlResponseDto>
{
    public async ValueTask<GetCategoryLogoGetUrlResponseDto> Handle(GetCategoryLogoGetUrlCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .AsTracking()
            .SingleOrDefaultAsync(c => c.Id == request.RouteDto.CategoryId, cancellationToken);
        if (ReferenceEquals(category, default))
        {
            throw new ArgumentOutOfRangeException(nameof(request.RouteDto.CategoryId), "Category not found");
        }

        var presignedUrl = await minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
            .WithObject(category.LogoId.ToString())
            .WithBucket("categories")
            .WithExpiry(60 * 60));

        return new GetCategoryLogoGetUrlResponseDto
        {
            Logo = presignedUrl
        };
    }
}