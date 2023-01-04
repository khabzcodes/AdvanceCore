using AdvanceCore.Application.Organizations.Queries.GetUserOrganization;
using AdvanceCore.Application.UserProfile.Common;
using AdvanceCore.Application.UserProfile.Queries;
using AdvanceCore.Contracts.UserProfile;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvanceCore.API.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class ProfilesController : ApiController
    {
        private readonly ISender _mediator;

        public ProfilesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            if (user == null) return Unauthorized();

            GetUserProfileQuery query = new GetUserProfileQuery(user.Value);

            ErrorOr<UserProfileResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(result => Ok(result), error => Problem(error));
        }
    }
}
