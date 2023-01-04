using AdvanceCore.Application.UserProfile.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.UserProfile.Queries;

public record GetUserProfileQuery(
    string UserId
    ) : IRequest<ErrorOr<UserProfileResponse>>;
