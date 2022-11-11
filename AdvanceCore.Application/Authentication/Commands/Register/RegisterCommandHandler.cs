using MediatR;
using ErrorOr;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using AdvanceCore.Domain.Constants;
using AdvanceCore.Application.Common.Interface.Authentication;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public RegisterCommandHandler(
        UserManager<ApplicationUser> userManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IOrganizationRepository organizationRepository,
        IOrganizationUserRepository organizationUserRepository)
    {
        _userManager = userManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _organizationRepository = organizationRepository;
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<AuthResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        ApplicationUser user = ApplicationUser.Create(
            command.firstName,
            command.lastName,
            command.email,
            DateTime.UtcNow);

        var createUserResult = await _userManager.CreateAsync(user, command.password);

        await _userManager.AddToRoleAsync(user, Constants.UserRole);

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user.Id);

        Organization organization = Organization.Create(
            Guid.NewGuid(),
            command.companyName,
            command.companyEmail,
            user.Id,
            DateTime.UtcNow);

        var createOrganization = _organizationRepository.Add(organization);

        OrganizationUser organizationUser = OrganizationUser.Create(
            organization.Id,
            user.Id,
            null,
            null,
            null);

        _organizationUserRepository.Add(organizationUser);

        return new AuthResponse(Token: jwtToken);
    }
}