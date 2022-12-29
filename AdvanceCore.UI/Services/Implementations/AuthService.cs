using AdvanceCore.Contracts.Authentication;
using AdvanceCore.UI.Models.ApiReponse;
using AdvanceCore.UI.Models.ApiReponse.Authentication;
using AdvanceCore.UI.Models.ViewModels.Authentication;
using Blazored.LocalStorage;
using FluentResults;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AdvanceCore.UI.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;
    public AuthService(
        HttpClient httpClient, 
        ILocalStorageService localStorageService
        )
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<Result<AuthResponse>> Login(LoginViewModel model)
    {
        LoginRequest loginRequest = new(model.Email, model.Password);

        HttpResponseMessage? response = await _httpClient.PostAsJsonAsync("/api/auth/login", loginRequest);

        var jsonString = response.Content.ReadAsStringAsync().Result;

        if (!response.IsSuccessStatusCode)
        {
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(jsonString);

            return Result.Fail(new Error(errorResponse.Title));
        }

        AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonString);
        Console.WriteLine(authResponse.Token);
        await _localStorageService.SetItemAsync<string>("authToken", authResponse.Token);
        return new AuthResponse(authResponse.Token);
    }

    public async Task<Result<AuthResponse>> RegisterAccount(RegisterViewModel model)
    {
        RegisterRequest registerRequest = new(model.FirstName, model.LastName, model.Email, model.Password, model.CompanyName, model.CompanyEmail);

        HttpResponseMessage? response = await _httpClient.PostAsJsonAsync("/api/auth/register", registerRequest);

        ////Console.WriteLine(JsonSerializer.Serialize(response));

        var jsonString = response.Content.ReadAsStringAsync().Result;

        if (!response.IsSuccessStatusCode)
        {
            ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(jsonString);

            return Result.Fail(new Error(errorResponse.Title));
        }

        AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(jsonString);

        return new AuthResponse(authResponse.Token);
    }
}
