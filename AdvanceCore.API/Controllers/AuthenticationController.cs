using AdvanceCore.Application.Authentication;
using AdvanceCore.Application.Authentication.Commands.Register;
using AdvanceCore.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        RegisterCommand command = new RegisterCommand(
            request.firstName,
            request.lastName,
            request.email,
            request.password,
            request.companyName,
            request.companyEmail);

        AuthenticationResult result = await _mediator.Send(command, cancellationToken);

        return Ok();
    }

    public static AuthenticationResult MapAuthenticationResult(AuthenticationResult response)
    {
        return new AuthenticationResult() { Token = response.Token };
    }
}