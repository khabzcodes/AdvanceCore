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
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationUserRepository _organizationUserRepository;
    private readonly IOrganizationUserRoleRepository _organizationUserRoleRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        UserManager<ApplicationUser> userManager,
        IOrganizationRepository organizationRepository,
        IOrganizationUserRepository organizationUserRepository,
        IOrganizationUserRoleRepository organizationUserRoleRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _organizationRepository = organizationRepository;
        _organizationUserRepository = organizationUserRepository;
        _organizationUserRoleRepository = organizationUserRoleRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        ApplicationUser user = new()
        {
            FirstName = command.firstName,
            LastName = command.lastName,
            UserName = command.email,
            Email = command.email
        };
        // Insert user details to db
        var createUserResult = await _userManager.CreateAsync(user, command.password);

        await _userManager.AddToRoleAsync(user, Constants.UserRole);
        // Generate jwt token
        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user.Id);
        // Insert organization to db
        Organization organization = new()
        {
            Name = command.companyName,
            Email = command.companyEmail,
            OrganizationsUsers = new List<OrganizationUser>(),
            CreatedBy = user.Id,
        };

        var createOrganization = _organizationRepository.AddOrganization(organization);

        OrganizationUserRole? adminRole = _organizationUserRoleRepository.GetOrganizationUserRoleByName(Constants.Administrator);

        if (adminRole == null) return Error.Failure();

        // Insert organization user to db
        OrganizationUser organizationUser = new()
        {
            OrganizationId = organization.Id,
            UserId = user.Id,
            OrganizationUserRoleId = Guid.Parse(adminRole.Id.ToString()),
            CreatedBy = user.Id,
        };

        _organizationUserRepository.AddOrganizationUser(organizationUser);

        return new AuthResponse(Token: jwtToken);
    }
}