using AdvanceCore.Application.Clients.Common;
using Newtonsoft.Json;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClients;
public record GetOrganizationClientsQuery(
    [JsonProperty("organizationId")]
    Guid OrganizationId
    ): IRequest<ErrorOr<ClientsResponse>>;
