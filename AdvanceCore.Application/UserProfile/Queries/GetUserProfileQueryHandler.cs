using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Application.UserProfile.Common;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.UserProfile.Queries;

public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, ErrorOr<UserProfileResponse>>
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public GetUserProfileQueryHandler(
        IUserProfileRepository userProfileRepository,
        IOrganizationRepository organizationRepository)
    {
        _userProfileRepository = userProfileRepository;
        _organizationRepository = organizationRepository;
    }
    public async Task<ErrorOr<UserProfileResponse>> Handle(
        GetUserProfileQuery query, 
        CancellationToken cancellationToken
        )
    {
        ApplicationUser? user = _userProfileRepository.GetById(query.UserId);

        if (user == null) return UserProfileErrors.UserProfileNotFound;

        List<Organization> organizations = _organizationRepository.GetByUserId(query.UserId);

        UserProfileResponse response = new(user, organizations);

        return await Task.FromResult(response);
    }
}
