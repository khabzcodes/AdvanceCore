using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;

namespace AdvanceCore.UI.Helpers;

public class AuthStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationState _anonymous;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public AuthStateProvider(
        HttpClient httpClient,
        ILocalStorageService localStorage,
        JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await _localStorage.GetItemAsync<string>("authToken");
        if (string.IsNullOrWhiteSpace(savedToken)) return _anonymous;
                                                                                                          
        JwtSecurityToken jwtSecurityToken = _jwtSecurityTokenHandler.ReadJwtToken(savedToken);
        DateTime expiryDate = jwtSecurityToken.ValidTo;

        if (expiryDate < DateTime.UtcNow)
        {
            await _localStorage.RemoveItemAsync("authToken");
            return _anonymous;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(savedToken), "jwtAuthType")));
    }

    public void NotifyUserAuthentication(string email)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "jwtAuthType"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }
    public void NotifyUserLogout()
    {
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}
