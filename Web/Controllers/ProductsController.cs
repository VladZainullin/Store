using Application.Contracts.Features.Products.Commands.CreateProduct;
using Application.Contracts.Features.Products.Commands.DeleteProducts;
using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("products")]
public sealed class ProductsController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateProductResponseDto>> CreateProductAsync(
        [FromBody] CreateProductBodyDto bodyDto)
    {
        var response = await Sender.Send(new CreateProductCommand(bodyDto), HttpContext.RequestAborted);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPut]
    public async Task<NoContentResult> UpdateProductAsync(
        [FromRoute] UpdateProductRouteDto routeDto,
        [FromBody] UpdateProductBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeleteProductAsync(
        [FromBody] DeleteProductsBodyDto bodyDto)
    {
        await Sender.Send(new DeleteProductsCommand(bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}