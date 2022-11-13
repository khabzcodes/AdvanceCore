using FluentValidation;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.AcceptOrganizationInvite;

public class AcceptOrganizationInviteValidator : AbstractValidator<AcceptOrganizationInviteCommand>
{
    public AcceptOrganizationInviteValidator()
    {
        // First name
        RuleFor(x => x.firstName).NotEmpty().WithMessage("First name is required")
            .Length(2, 40)
            .When(x => !string.IsNullOrEmpty(x.firstName))
            .WithMessage("First name must be between 2-40 characters in length");

        // Last name
        RuleFor(x => x.lastName).NotEmpty().WithMessage("Last name is required")
            .Length(2, 40)
            .When(x => !string.IsNullOrEmpty(x.lastName))
            .WithMessage("Last name must be between 2-40 characters in length");

        // Email
        RuleFor(x => x.email).NotEmpty().WithMessage("Email address is required")
            .When(x => !string.IsNullOrEmpty(x.email))
            .EmailAddress().WithMessage("A valid email address is required");

        // Password
        RuleFor(x => x.password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
    }
}