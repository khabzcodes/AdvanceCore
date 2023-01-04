using AdvanceCore.Application.Workspaces.Common;
using AdvanceCore.Application.Workspaces.Queries.GetWorkspace;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvanceCore.API.Controllers
{
    [Authorize]
    [Route("api/workspaces")]
    public class WorkspacesController : ApiController
    {
        private readonly ISender _mediator;
        public WorkspacesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            if (user == null) return Unauthorized();

            GetWorkspaceQuery query = new(user.Value);

            ErrorOr<WorkspaceResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(result => Ok(result), error => Problem(error));
        }
    }
}
