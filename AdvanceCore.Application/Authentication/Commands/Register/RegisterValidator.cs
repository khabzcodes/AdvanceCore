using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterValidator(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;

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
            .EmailAddress().WithMessage("A valid email address is required")
            .Must(BeUniqueEmailAddress).WithMessage("Email is already taken");

        // Password
        RuleFor(x => x.password).NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        // .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

        // Company name
        RuleFor(x => x.companyName).NotEmpty().WithMessage("Company name is required")
            .Length(2, 40)
            .When(x => !string.IsNullOrEmpty(x.companyName))
            .WithMessage("Company name must be between 2-40 characters in length");

        // Company email
        RuleFor(x => x.companyEmail).NotEmpty().WithMessage("Company email address is required")
            .When(x => !string.IsNullOrEmpty(x.companyEmail))
            .EmailAddress().WithMessage("A valid company email address is required");
    }

    public bool BeUniqueEmailAddress(string email)
    {
        ApplicationUser? user = _userManager.FindByEmailAsync(email).Result;

        return user != null ? false : true;
    }

    public bool BeUniqueCompanyEmailAddress(string companyEmail)
    {
        return false;
    }
}