using System.Security.Claims;
using AdvanceCore.Application.OrganizationUserInvites.Commands.InviteOrganizationUser;
using AdvanceCore.Application.OrganizationUserInvites.Common;
using AdvanceCore.Application.OrganizationUserInvites.Queries.GetOrganizationInvites;
using AdvanceCore.Contracts.OrganizationInvite;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

[Route("/api/organizationInvites")]
public class OrganizationInviteController : ApiController
{
    private readonly ISender _mediator;
    public OrganizationInviteController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(InviteOrganizationUserRequest request, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var command = new InviteOrganizationUserCommand(request.organizationId, request.email, request.role, user.Value);

        var inviteOrganizationUserResult = await _mediator.Send(command, cancellationToken);

        return inviteOrganizationUserResult.Match(
            inviteOrganizationUserResult => Ok(inviteOrganizationUserResult),
            error => Problem(error));
    }

    [HttpGet]
    public async Task<IActionResult> OrganizationInvites([FromQuery] Guid organizationId, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new OrganizationInvitesQuery(organizationId);
        ErrorOr<OrganizationInvitesResponse> organizationInvitesResult = await _mediator.Send(query, cancellationToken);

        return organizationInvitesResult.Match(
            organizationInvitesResult => Ok(organizationInvitesResult),
            error => Problem(error));
    }
}