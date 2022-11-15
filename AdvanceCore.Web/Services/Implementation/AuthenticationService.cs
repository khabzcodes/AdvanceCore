using System.Net.Http.Json;

namespace AdvanceCore.Web.Services.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}