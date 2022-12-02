using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Contracts.Clients;

public record CreateClientRequest(
    [JsonProperty("organizationId")]
    Guid OrganizationId,
    [JsonProperty("name")]
    string Name,
    [JsonProperty("description")]
    string? Description
    );
