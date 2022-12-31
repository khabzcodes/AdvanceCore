using AdvanceCore.UI.Models.ApiReponse.UserProfile;
using FluentResults;

namespace AdvanceCore.UI.Services;

public interface IUserProfileService
{
    Task<Result<UserProfileResponse>> Profile();
}
