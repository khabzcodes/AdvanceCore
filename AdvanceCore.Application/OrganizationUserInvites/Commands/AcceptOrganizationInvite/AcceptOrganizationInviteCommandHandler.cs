using AdvanceCore.Application.Authentication;
using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Common.Interface.Authentication;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Constants;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.AcceptOrganizationInvite;

public class AcceptOrganizationInviteCommandHandler : IRequestHandler<AcceptOrganizationInviteCommand, ErrorOr<AuthResponse>>
{
    private readonly IOrganizationInviteRepository _organizationInviteRepository;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public AcceptOrganizationInviteCommandHandler(
        IOrganizationInviteRepository organizationInviteRepository,
        UserManager<ApplicationUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IOrganizationUserRepository organizationUserRepository)
    {
        _organizationInviteRepository = organizationInviteRepository;
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<AuthResponse>> Handle(AcceptOrganizationInviteCommand command, CancellationToken cancellationToken)
    {
        var organizationInvite = _organizationInviteRepository.GetById(command.organizationInviteId);

        if (organizationInvite is null) return OrganizationUserInviteErrors.InviteNotFound;

        if (organizationInvite.Email != command.email) return OrganizationUserInviteErrors.InviteNotFound;

        ApplicationUser user = ApplicationUser.Create(
            command.firstName,
            command.lastName,
            command.email,
            DateTime.UtcNow
        );

        await _userManager.CreateAsync(user, command.password);

        await _userManager.AddToRoleAsync(user, Constants.UserRole);

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user.Id, user.Email);

        OrganizationUser? defaultOrganizationUser = _organizationUserRepository.GetDefaultOrganizationUser(user.Id);

        bool isDefaultOrganization;
        if (defaultOrganizationUser is null)
        {
            isDefaultOrganization = true;
        }
        else
        {
            defaultOrganizationUser.IsDefault = false;
            _organizationUserRepository.Update(defaultOrganizationUser);

            isDefaultOrganization = true;
        }

        OrganizationUser organizationUser = OrganizationUser.Create(
            Guid.NewGuid(),
            organizationInvite.OrganizationId,
            user.Id,
            user.Email,
            organizationInvite.Role,
            null,
            null,
            true,
            isDefaultOrganization,
            DateTime.UtcNow);

        _organizationUserRepository.Add(organizationUser);

        _organizationInviteRepository.Remove(organizationInvite);

        return new AuthResponse(Token: jwtToken);
    }
}