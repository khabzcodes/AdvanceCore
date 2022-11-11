using System.Security.Claims;
using AdvanceCore.Application.Organizations.Common;
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

    [HttpGet]
    public async Task<IActionResult> Organizations(CancellationToken cancellationToken)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null) return Unauthorized();

        var query = new GetUserOrganizationsQuery(user.Value);

        ErrorOr<OrganizationsResponse> organizationsResult = await _mediator.Send(query, cancellationToken);

        return organizationsResult.Match(
            organizationsResult => Ok(organizationsResult),
            errors => Problem(errors));
    }
}