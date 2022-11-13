using System.Security.Claims;
using AdvanceCore.Application.OrganizationUsers.Commands.UpdateOrganizationUser;
using AdvanceCore.Application.OrganizationUsers.Common;
using AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUser;
using AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUsers;
using AdvanceCore.Contracts.OrganizationUsers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

[Authorize]
[Route("/api/organizationUsers")]
public class OrganizationUsersController : ApiController
{
    private readonly ISender _mediator;

    public OrganizationUsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] Guid organizationId, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetOrganizationUsersQuery(organizationId, user.Value);

        ErrorOr<OrganizationUsersResponse> organizationUsersResult = await _mediator.Send(query, cancellationToken);

        return organizationUsersResult.Match(
            organizationUsersResult => Ok(organizationUsersResult),
            error => Problem(error));
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get([FromQuery] GetOrganizationUserRequest request, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetOrganizationUserQuery(request.organizationUserId, request.organizationId);

        ErrorOr<OrganizationUserResponse> organizationUserResult = await _mediator.Send(query, cancellationToken);

        return organizationUserResult.Match(
            organizationUserResult => Ok(organizationUserResult),
            error => Problem(error));
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateOrganizationUserRequest request, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        UpdateOrganizationUserCommand? command = new UpdateOrganizationUserCommand(
            request.organizationId,
            request.organizationUserId,
            user.Value,
            request.primaryContactNumber,
            request.secondaryContactNumber);

        ErrorOr<OrganizationUserResponse> organizationUserResult = await _mediator.Send(command, cancellationToken);

        return organizationUserResult.Match(
            organizationUserResult => Ok(organizationUserResult),
            error => Problem(error));
    }
}