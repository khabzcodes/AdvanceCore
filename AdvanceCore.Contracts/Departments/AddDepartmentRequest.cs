using Newtonsoft.Json;

namespace AdvanceCore.Contracts.Departments;

public record AddDepartmentRequest(
    [JsonProperty("organizationId")]
    Guid OrganizationId,
    [JsonProperty("name")]
    string Name,
    [JsonProperty("description")]
    string? Description
    );
