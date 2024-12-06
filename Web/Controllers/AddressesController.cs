using Application.Contracts.Features.Addresses.Commands.CreateAddress;
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
}