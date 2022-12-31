using Newtonsoft.Json;

namespace AdvanceCore.UI.Models.ApiReponse.Organizations;

public record OrganizationResponse(
    [JsonProperty("id")]
    string Id,
    [JsonProperty("name")]
    string Email,
    [JsonProperty("creatorId")]
    string CreatorId,
    [JsonProperty("createdAtUtc")]
    DateTime CreatedAtUtc
    );

//"id": "a7d0356b-4a33-4754-8ba8-455c27e7c765",
//            "name": "Kashings",
//            "email": "info@kashings.com",
//            "creatorId": "40aa8a18-3510-43ee-8019-7753e78bfbac",
//"createdAtUtc": "2022-12-31T13:13:00.92127"
