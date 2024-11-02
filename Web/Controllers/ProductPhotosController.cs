using Application.Contracts.Features.Products.Commands.UpdateProductPhoto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products/{productId:guid}/photos")]
public sealed class ProductPhotosController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateProductPhotoAsync(
        [FromRoute] UpdateProductPhotoRequestRouteDto routeDto,
        [FromForm] UpdateProductPhotoRequestFormDto formDto)
    {
        await Sender.Send(new UpdateProductPhotoCommand(routeDto, formDto), HttpContext.RequestAborted);
        
        return NoContent();
    }
}