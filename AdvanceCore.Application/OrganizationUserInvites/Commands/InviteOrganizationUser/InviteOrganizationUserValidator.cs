using FluentValidation;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.InviteOrganizationUser;

public class InviteOrganizationUserValidator : AbstractValidator<InviteOrganizationUserCommand>
{
    public InviteOrganizationUserValidator()
    {
        RuleFor(x => x.email).NotEmpty().WithMessage("Email address is required")
            .When(x => !string.IsNullOrEmpty(x.email))
            .EmailAddress().WithMessage("A valid email address is required");

        RuleFor(x => x.organizationId).NotEmpty().WithMessage("Organization id is required");
    }
}