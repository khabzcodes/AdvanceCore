using AdvanceCore.Domain.Entities;
using Newtonsoft.Json;

namespace AdvanceCore.Application.UserProfile.Common;

public record UserProfileResponse(
    [JsonProperty("user")]
    ApplicationUser User,                   
    [JsonProperty("organizations")]
    List<Organization> Organizations
    );
