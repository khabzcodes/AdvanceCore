using MediatR;
using ErrorOr;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using AdvanceCore.Domain.Constants;
using AdvanceCore.Application.Common.Interface.Authentication;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<RegisterResponse>>
{
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IOrganizationUserRepository _organizationUserRepository;
    private readonly IOrganizationUserRoleRepository _organizationUserRoleRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMediator _mediator;

    public RegisterCommandHandler(
        IIdentityUserRepository identityUserRepository,
        IOrganizationRepository organizationRepository,
        IOrganizationUserRepository organizationUserRepository,
        IOrganizationUserRoleRepository organizationUserRoleRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IMediator mediator)
    {
        _identityUserRepository = identityUserRepository;
        _organizationRepository = organizationRepository;
        _organizationUserRepository = organizationUserRepository;
        _organizationUserRoleRepository = organizationUserRoleRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mediator = mediator;
    }

    public async Task<ErrorOr<RegisterResponse>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        ApplicationUser user = new()
        {
            FirstName = command.firstName,
            LastName = command.lastName,
            UserName = command.email,
            Email = command.email
        };
        // Insert user details to db
        var createUserResult = await _identityUserRepository.CreateApplicationUser(user, command.password);

        await _identityUserRepository.AssignRoleToUserAsync(user, Constants.UserRole);
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

        // TODO: return a detailed error message
        if (adminRole == null) throw new Exception("");

        // Insert organization user to db
        OrganizationUser organizationUser = new()
        {
            OrganizationId = organization.Id,
            UserId = user.Id,
            OrganizationUserRoleId = Guid.Parse(adminRole.Id.ToString()),
            CreatedBy = user.Id,
        };

        _organizationUserRepository.AddOrganizationUser(organizationUser);

        return new RegisterResponse(Token: jwtToken);
    }
}