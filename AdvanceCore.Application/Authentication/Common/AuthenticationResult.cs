namespace AdvanceCore.Application.Authentication;

public record AuthenticationResult
{
    public string Token { get; set; } = string.Empty;
}