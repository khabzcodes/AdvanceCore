using AdvanceCore.Contracts.Authentication;
using AdvanceCore.UI.Models.ApiReponse;
using AdvanceCore.UI.Models.ApiReponse.UserProfile;
using FluentResults;
using Newtonsoft.Json;
using System.Net.Http.Json;
namespace AdvanceCore.UI.Services.Implementations;

public class UserProfileService : IUserProfileService
{
    private readonly HttpClient _httpClient;

    public UserProfileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<UserProfileResponse>> Profile()
    {
        HttpResponseMessage? response = await _httpClient.GetAsync("/api/users");
        string? jsonString = response.Content.ReadAsStringAsync().Result;

        if (!response.IsSuccessStatusCode)
        {
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(jsonString);

            return Result.Fail(new Error(errorResponse.Title));
        }

        UserProfileResponse authResponse = JsonConvert.DeserializeObject<UserProfileResponse>(jsonString);


        return await Task.FromResult(new UserProfileResponse(User: authResponse.User, Organizations: authResponse.Organizations));
    }
}
