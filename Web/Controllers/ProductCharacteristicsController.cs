using Application.Contracts.Features.Products.Commands.AddCharacteristicToProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/products/{productId:guid}/characteristics")]
public sealed class ProductCharacteristicsController : AppController
{
    [HttpPost]
    public async Task<StatusCodeResult> AddProductCharacteristicAsync(
        [FromRoute] AddCharacteristicToProductRequestRouteDto route,
        [FromBody] AddCharacteristicToProductRequestBodyDto body)
    {
        await Sender.Send(new AddCharacteristicToProductCommand(route, body), HttpContext.RequestAborted);
        
        return StatusCode(StatusCodes.Status201Created);
    }
}