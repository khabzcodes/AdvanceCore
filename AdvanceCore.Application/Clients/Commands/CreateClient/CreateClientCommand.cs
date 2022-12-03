using AdvanceCore.Application.Clients.Common;
using ErrorOr;
using MediatR;
using Newtonsoft.Json;

namespace AdvanceCore.Application.Clients.Commands.CreateClient;

public record CreateClientCommand(
    [JsonProperty("organizationId")]
    Guid OrganizationId,
    [JsonProperty("userId")]
    string UserId,
    [JsonProperty("name")]
    string Name,
    [JsonProperty("description")]
    string? Description
    ): IRequest<ErrorOr<ClientResponse>>;
