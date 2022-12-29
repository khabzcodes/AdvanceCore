using AdvanceCore.Application.Authentication;
using AdvanceCore.Application.Authentication.Commands.Register;
using AdvanceCore.Application.Authentication.Queries.Login;
using AdvanceCore.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Register an account and created an organization
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A JWT token</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterCommand(
            request.firstName,
            request.lastName,
            request.email,
            request.password,
            request.companyName,
            request.companyEmail
            );

        ErrorOr<AuthResponse> authResult = await _mediator.Send(command, cancellationToken);

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }

    /// <summary>
    /// Login to your account
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>A JWT token</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var query = new LoginQuery(request.email, request.password);

        ErrorOr<AuthResponse> authResult = await _mediator.Send(query, cancellationToken);

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors));
    }
}