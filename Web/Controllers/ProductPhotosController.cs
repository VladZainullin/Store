using Application.Contracts.Features.Categories.Commands.AddPhotoToProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products/{productId:guid}/photos")]
public sealed class ProductPhotosController : AppController
{
    [HttpPost]
    public async Task<ActionResult<AddPhotoToProductResponseDto>> AddPhotoToProductAsync(
        [FromRoute] AddPhotoToProductRequestRouteDto routeDto,
        [FromForm] AddPhotoToProductRequestFormDto formDto)
    {
        return Ok(await Sender.Send(new AddPhotoToProductCommand(routeDto, formDto), HttpContext.RequestAborted));
    }
}