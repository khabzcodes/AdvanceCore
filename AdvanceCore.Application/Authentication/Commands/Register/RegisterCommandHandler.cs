using MediatR;
using FluentResults;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using AdvanceCore.Application.Common.Interface.Authentication;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMediator _mediator;

    public RegisterCommandHandler(
        IIdentityUserRepository identityUserRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IMediator mediator)
    {
        _identityUserRepository = identityUserRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mediator = mediator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _identityUserRepository.GetApplicationUserByEmailAsync(command.email) is not null)
        {
            // Return user already exist error message
        }

        ApplicationUser user = new()
        {
            FirstName = command.firstName,
            LastName = command.lastName,
            UserName = command.email,
            Email = command.email
        };

        var createUserResult = await _identityUserRepository.CreateApplicationUser(user, command.password);

        if (!createUserResult.Succeeded)
        {
            // Return user cannot be created error message
        }

        await _identityUserRepository.AssignRoleToUserAsync(user, "USER");

        var jwtToken = _jwtTokenGenerator.GenerateJwtToken(user.Id);

        if (String.IsNullOrEmpty(jwtToken))
        {
            // Return server error
        }

        return new AuthenticationResult() { Token = jwtToken };
    }
}