using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClients;

public class GetOrganizationClientsValidator : AbstractValidator<GetOrganizationClientsQuery>
{
    public GetOrganizationClientsValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization id is required");
    }
}
