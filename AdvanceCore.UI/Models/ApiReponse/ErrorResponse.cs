using Newtonsoft.Json;

namespace AdvanceCore.UI.Models.ApiReponse;

public record ErrorResponse(
    [JsonProperty("type")]
    string Type,
    [JsonProperty("title")]
    string Title,
    [JsonProperty("status")]
    string Status
    );
