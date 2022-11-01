using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

public class ErrorsController : ControllerBase
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(statusCode: 400, title: exception?.Message);
    }
}