using AdvanceCore.Application.Clients.Common;
using ErrorOr;
using MediatR;
using Newtonsoft.Json;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClient;

public record GetOrganizationClientQuery(
    [JsonProperty("clientId")]
    Guid ClientId,
    [JsonProperty("organizationId")]
    Guid OrganizationId
    ) : IRequest<ErrorOr<ClientResponse>>;
