using FluentValidation;

namespace AdvanceCore.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        // Email
        RuleFor(x => x.email).NotEmpty().WithMessage("Email address is required")
            .When(x => !string.IsNullOrEmpty(x.email))
            .EmailAddress().WithMessage("A valid email address is required");

        // Password
        RuleFor(x => x.password).NotEmpty().WithMessage("Password is required");
    }
}