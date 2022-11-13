using FluentValidation;

namespace AdvanceCore.Application.OrganizationUsers.Commands.UpdateOrganizationUser;

public class UpdateOrganizationUserCommandValidator : AbstractValidator<UpdateOrganizationUserCommand>
{
    public UpdateOrganizationUserCommandValidator()
    {
        RuleFor(x => x.organizationId).NotEmpty().WithMessage("Organization id is required");

        RuleFor(x => x.organizationUserId).NotEmpty().WithMessage("Organization user id is required");

        RuleFor(x => x.userId).NotEmpty().WithMessage("User id is required");
        // TODO: custom phone number validator
    }
}