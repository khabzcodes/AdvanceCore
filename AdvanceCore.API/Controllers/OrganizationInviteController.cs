using System.Security.Claims;
using AdvanceCore.Application.Authentication;
using AdvanceCore.Application.OrganizationUserInvites.Commands.AcceptOrganizationInvite;
using AdvanceCore.Application.OrganizationUserInvites.Commands.InviteOrganizationUser;
using AdvanceCore.Application.OrganizationUserInvites.Common;
using AdvanceCore.Application.OrganizationUserInvites.Queries.GetOrganizationInvites;
using AdvanceCore.Contracts.OrganizationInvite;
using AdvanceCore.Contracts.OrganizationUsers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
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

    [Authorize]
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

    [HttpPost("acceptInvitation")]
    public async Task<IActionResult> AcceptInvitation(AcceptOrganizationInviteRequest request, CancellationToken cancellationToken)
    {
        AcceptOrganizationInviteCommand? command = new AcceptOrganizationInviteCommand(
            request.organizationInviteId,
            request.firstName,
            request.lastName,
            request.email,
            request.password);

        ErrorOr<AuthResponse> result = await _mediator.Send(command, cancellationToken);

        return result.Match(
            result => Ok(result),
            error => Problem(error));
    }
}