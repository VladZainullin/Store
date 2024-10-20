using System.Net.Mime;
using Application.Contracts.Features.Categories.Queries.GetProductPhoto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products/{productId:guid}/photos")]
public sealed class ProductPhotosController : AppController
{
    [HttpGet]
    public async Task<FileResult> GetProductPhotoAsync(
        [FromRoute] GetProductPhotoRequestRouteDto routeDto)
    {
        var response = await Sender.Send(new GetProductPhotoQuery(routeDto));
        
        return File(response.Stream, MediaTypeNames.Application.Octet);
    }
}