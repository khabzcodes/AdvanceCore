using Newtonsoft.Json;

namespace AdvanceCore.UI.Models.ApiReponse.Authentication;

public record AuthResponse(
    [JsonProperty("token")]
    string Token
    );
