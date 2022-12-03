using AdvanceCore.Application.Clients.Commands.CreateClient;
using AdvanceCore.Application.Clients.Common;
using AdvanceCore.Application.Clients.Queries.GetOrganizationClient;
using AdvanceCore.Application.Clients.Queries.GetOrganizationClients;
using AdvanceCore.Contracts.Clients;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        /// <summary>
        /// Add organization client
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get organization clients by organization id
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("getClients")]
        [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] Guid organizationId, CancellationToken cancellationToken)
        {
            GetOrganizationClientsQuery query = new GetOrganizationClientsQuery(organizationId);

            ErrorOr<ClientsResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error));
        }

        [HttpGet("getClient")]
        public async Task<IActionResult> Get(
            [FromQuery] Guid clientId,
            [FromQuery] Guid organizationId,
            CancellationToken cancellationToken)
        {
            GetOrganizationClientQuery query = new(clientId, organizationId);

            ErrorOr<ClientResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(
                result => Ok(result),
                error => Problem(error));
        }
    }
}
