using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Application.Workspaces.Common;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.Workspaces.Queries.GetWorkspace;

public class GetWorkspaceQueryHandler : IRequestHandler<GetWorkspaceQuery, ErrorOr<WorkspaceResponse>>
{
    private readonly IUserProfileRepository _userProfileRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public GetWorkspaceQueryHandler(
        IUserProfileRepository userProfileRepository, 
        IOrganizationRepository organizationRepository, 
        IOrganizationUserRepository organizationUserRepository)
    {
        _userProfileRepository = userProfileRepository;
        _organizationRepository = organizationRepository;
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<WorkspaceResponse>> Handle(
        GetWorkspaceQuery query, 
        CancellationToken cancellationToken)
    {
        ApplicationUser? user = _userProfileRepository.GetById(query.UserId);

        if (user == null) return UserProfileErrors.UserProfileNotFound;

        OrganizationUser? organizationUser = _organizationUserRepository.GetDefaultOrganizationUser(query.UserId);

        // TODO: return workspace not found error

        if (organizationUser == null) return OrganizationUserErrors.OrganizationUserNotFound;

        Organization? organization = _organizationRepository.GetById(organizationUser.OrganizationId);

        if (organization == null) return OrganizationErrors.OrganizationNotFound;

        return await Task.FromResult(new WorkspaceResponse(User: user, Organization: organization));
    }
}
