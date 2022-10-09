using FluentValidation;
using MediatR;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    private readonly IMediator _mediator;

    public RegisterValidator(IMediator mediator)
    {
        _mediator = mediator;

        // First name
        RuleFor(x => x.firstName).NotEmpty().WithMessage("Please enter your first name");
        RuleFor(x => x.firstName).Length(2, 40)
        .When(x => !string.IsNullOrEmpty(x.firstName))
        .WithMessage("First name must be between 2-40 characters in length");

        // Last name
        RuleFor(x => x.lastName).NotEmpty().WithMessage("Please enter your last name");
        RuleFor(x => x.lastName).Length(2, 40)
        .When(x => !string.IsNullOrEmpty(x.lastName))
        .WithMessage("Last name must be between 2-40 characters in length");

        // Email
        RuleFor(x => x.email).NotEmpty().WithMessage("Please enter your email address");
        RuleFor(x => x.email).EmailAddress().WithMessage("Please enter a valid email address");
    }
}