using FluentValidation;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUser;

public class GetOrganizationUserQueryValidator : AbstractValidator<GetOrganizationUserQuery>
{
    public GetOrganizationUserQueryValidator()
    {
        RuleFor(x => x.organizationId).NotEmpty().WithMessage("Organization id is required");
        RuleFor(x => x.organizationUserId).NotEmpty().WithMessage("Organization user id is required");
    }
}