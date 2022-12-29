using AdvanceCore.UI.Models.ApiReponse.Authentication;
using AdvanceCore.UI.Models.ViewModels.Authentication;
using FluentResults;

namespace AdvanceCore.UI.Services;

public interface IAuthService
{
    Task<Result<AuthResponse>> RegisterAccount(RegisterViewModel model);
    Task<Result<AuthResponse>> Login(LoginViewModel model);
}
