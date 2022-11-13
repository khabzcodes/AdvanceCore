using System.Security.Claims;
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

    [HttpGet("getOrganizationUsers")]
    public async Task<IActionResult> GetOrganizationUsers([FromQuery] Guid organizationId, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetOrganizationUsersQuery(organizationId, user.Value);

        ErrorOr<OrganizationUsersResponse> organizationUsersResult = await _mediator.Send(query, cancellationToken);

        return organizationUsersResult.Match(
            organizationUsersResult => Ok(organizationUsersResult),
            error => Problem(error));
    }

    [HttpGet("getOrganizationUser")]
    public async Task<IActionResult> GetOrganizationUser([FromQuery] GetOrganizationUserRequest request, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetOrganizationUserQuery(request.organizationUserId, request.organizationId);

        ErrorOr<OrganizationUserResponse> organizationUserResult = await _mediator.Send(query, cancellationToken);

        return organizationUserResult.Match(
            organizationUserResult => Ok(organizationUserResult),
            error => Problem(error));
    }
}