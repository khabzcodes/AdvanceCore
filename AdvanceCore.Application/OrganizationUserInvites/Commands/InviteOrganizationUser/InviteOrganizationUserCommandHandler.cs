using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.OrganizationUserInvites.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.InviteOrganizationUser;

public class InviteOrganizationUserCommandHandler : IRequestHandler<InviteOrganizationUserCommand, ErrorOr<OrganizationInviteResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOrganizationInviteRepository _organizationInviteRepository;
    private readonly IOrganizationUserRepository _organizationUserRepository;
    private readonly IOrganizationUserRoleRepository _organizationUserRoleRepository;

    public InviteOrganizationUserCommandHandler(
        IOrganizationInviteRepository organizationInviteRepository,
        UserManager<ApplicationUser> userManager,
        IOrganizationUserRepository organizationUserRepository,
        IOrganizationUserRoleRepository organizationUserRoleRepository)
    {
        _organizationInviteRepository = organizationInviteRepository;
        _userManager = userManager;
        _organizationUserRepository = organizationUserRepository;
        _organizationUserRoleRepository = organizationUserRoleRepository;
    }

    public async Task<ErrorOr<OrganizationInviteResponse>> Handle(InviteOrganizationUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);

        if (_organizationUserRepository.GetByOrganizationIdAndEmail(request.organizationId, request.email) is not null)
        {
            return OrganizationUserErrors.OrganizationUserAlreadyExist;
        }

        if (_organizationInviteRepository.GetByOrganizationIdAndEmail(request.organizationId, request.email) is not null)
        {
            return OrganizationUserInviteErrors.InviteAlreadySent;
        }

        if (_organizationUserRoleRepository.GetByName(request.role) is null)
        {
            return OrganizationUserRoleErrors.OrganizationUserRoleNotFound;
        }

        OrganizationInvite organizationInviteObj = OrganizationInvite.Create(
            request.organizationId,
            request.email,
            request.role,
            request.createdById);

        OrganizationInvite organizationInvite = _organizationInviteRepository.Add(organizationInviteObj);

        // TODO: send invitation email

        return new OrganizationInviteResponse(organizationInvite);
    }
}