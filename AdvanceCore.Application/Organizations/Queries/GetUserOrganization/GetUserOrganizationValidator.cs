using FluentValidation;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganization;

public class GetUserOrganizationValidator : AbstractValidator<GetUserOrganizationQuery>
{
    public GetUserOrganizationValidator()
    {
        RuleFor(x => x.organizationId).NotEmpty().WithMessage("Organization id is required");
    }
}