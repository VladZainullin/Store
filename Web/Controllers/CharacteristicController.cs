using Application.Contracts.Features.Characteristics.Commands.RemoveCharacteristic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/characteristics/{characteristicId:guid}")]
public sealed class CharacteristicController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> RemoveCharacteristicAsync(
        [FromRoute] RemoveCharacteristicRequestRouteDto route)
    {
        await Sender.Send(new RemoveCharacteristicCommand(route), HttpContext.RequestAborted);
        
        return NoContent();
    }
}