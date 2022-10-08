namespace AdvanceCore.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(string userId);
}