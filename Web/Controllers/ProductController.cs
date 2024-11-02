using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Application.Contracts.Features.Products.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products/{productId:guid}")]
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
}