using AdvanceCore.UI.Models.ApiReponse.Organizations;
using Newtonsoft.Json;

namespace AdvanceCore.UI.Models.ApiReponse.UserProfile;

public record UserProfileResponse(
    [JsonProperty("user")]
    UserResponse User,
    [JsonProperty("organizations")]
    List<OrganizationResponse> Organizations
    );


