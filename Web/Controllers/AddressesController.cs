using Application.Contracts.Features.Addresses.Commands.CreateAddress;
using Application.Contracts.Features.Addresses.Commands.RemoveAddress;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/addresses")]
public sealed class AddressesController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateAddressResponseDto>> CreateAddressAsync(
        [FromBody] CreateAddressRequestBodyDto body)
    {
        var response = await Sender.Send(new CreateAddressCommand(body), HttpContext.RequestAborted);
        
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpDelete("{addressId:guid}")]
    public async Task<ActionResult> RemoveAddressAsync(
        [FromRoute] RemoveAddressRequestRouteDto route)
    {
        await Sender.Send(new RemoveAddressCommand(route), HttpContext.RequestAborted);
    
        return NoContent();
    }
}