using FluentValidation;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganizations;

public class GetUserOrganizationsValidator : AbstractValidator<GetUserOrganizationsQuery>
{
    public GetUserOrganizationsValidator()
    {
        RuleFor(x => x.userId).NotEmpty().WithMessage("User id is required");
    }
}