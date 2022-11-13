using FluentValidation;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUsers;

public class GetOrganizationUsersValidator : AbstractValidator<GetOrganizationUsersQuery>
{
    public GetOrganizationUsersValidator()
    {
        RuleFor(x => x.organizationId).NotEmpty().WithMessage("Organization id is required");

        RuleFor(x => x.userId).NotEmpty().WithMessage("User id is required");
    }
}