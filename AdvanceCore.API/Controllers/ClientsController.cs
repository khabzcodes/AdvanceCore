using AdvanceCore.Application.Clients.Commands.CreateClient;
using AdvanceCore.Application.Clients.Common;
using AdvanceCore.Contracts.Clients;
using MediatR;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AdvanceCore.API.Controllers
{
    [Authorize]
    [Route("api/clients")]
    public class ClientsController : ApiController
    {
        private readonly ISender _mediator;

        public ClientsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier);
            if (user == null) return Unauthorized();

            CreateClientCommand? command = new CreateClientCommand(
                request.OrganizationId, 
                user.Value, 
                request.Name, 
                request.Description);

            ErrorOr<ClientResponse> result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error)
                );
        }
    }
}
