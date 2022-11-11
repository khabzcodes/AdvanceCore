using System.Security.Claims;
using AdvanceCore.Application.Organizations.Common;
using AdvanceCore.Application.Organizations.Queries.GetUserOrganization;
using AdvanceCore.Application.Organizations.Queries.GetUserOrganizations;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers;

[Authorize]
[Route("/api/organizations")]
public class OrganizationsController : ApiController
{

    private readonly ISender _mediator;

    public OrganizationsController(ISender mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get user organizations
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>An array of Organization object</returns>
    [HttpGet]
    [ProducesResponseType(typeof(OrganizationsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetUserOrganizationsQuery(user.Value);

        ErrorOr<OrganizationsResponse> organizationsResult = await _mediator.Send(query, cancellationToken);

        return organizationsResult.Match(
            organizationsResult => Ok(organizationsResult),
            errors => Problem(errors));
    }

    /// <summary>
    /// Get organization by organization id
    /// </summary>
    /// <param name="organizationId"></param>
    /// <returns></returns>
    [HttpGet("{organizationId}")]
    public async Task<IActionResult> Organization(Guid organizationId, CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetUserOrganizationQuery(organizationId, user.Value);

        ErrorOr<OrganizationResponse> organizationResult = await _mediator.Send(query, cancellationToken);

        return organizationResult.Match(organizationResult => Ok(organizationResult), error => Problem(error));
    }
}