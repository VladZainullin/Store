using Application.Contracts.Features.Products.Commands.FavoriteProduct;
using Application.Contracts.Features.Products.Commands.UnFavoriteProduct;
using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Application.Contracts.Features.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/products/{productId:guid}")]
public sealed class ProductController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductResponseDto>> GetProductAsync(
        [FromRoute] GetProductRequestRouteDto routeDto)
    {
        return Ok(await Sender.Send(new GetProductQuery(routeDto), HttpContext.RequestAborted));
    }
    
    [HttpPut]
    public async Task<NoContentResult> UpdateProductInCategoryAsync(
        [FromRoute] UpdateProductRequestRouteDto routeDto,
        [FromBody] UpdateProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpPut("favorite")]
    public async Task<NoContentResult> FavoriteProductAsync(
        [FromRoute] FavoriteProductRequestRouteDto routeDto)
    {
        await Sender.Send(new FavoriteProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpPut("unfavorite")]
    public async Task<NoContentResult> UnFavoriteProductAsync(
        [FromRoute] UnFavoriteProductRequestRouteDto routeDto)
    {
        await Sender.Send(new UnFavoriteProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}