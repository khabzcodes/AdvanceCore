using FluentValidation;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClient;

public class GetOrganizationClientValidator : AbstractValidator<GetOrganizationClientQuery>
{
    public GetOrganizationClientValidator()
    {
        RuleFor(x => x.ClientId).NotEmpty().WithMessage("Client id is required");
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization id is required");
    }
}
