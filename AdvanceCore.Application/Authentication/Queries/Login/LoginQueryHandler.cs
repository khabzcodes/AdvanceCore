using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Common.Interface.Authentication;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResponse>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<ApplicationUser> _userManager;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        UserManager<ApplicationUser> userManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
    }

    public async Task<ErrorOr<AuthResponse>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(query.email);
        if (user is null) return CustomErrors.Authentication.IncorrectEmailOrPassword;

        bool checkPassword = await _userManager.CheckPasswordAsync(user, query.password);
        if (!checkPassword) return CustomErrors.Authentication.IncorrectEmailOrPassword;

        string token = _jwtTokenGenerator.GenerateJwtToken(user.Id);
        if (String.IsNullOrEmpty(token)) return Error.Failure();

        return new AuthResponse(Token: token);
    }
}