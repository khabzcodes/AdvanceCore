using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Clients.Commands.CreateClient;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientValidator()
    {
        RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization id is required");

        RuleFor(x => x.Name).NotEmpty().WithMessage("Client name is required")
            .Length(2, 40)
            .When(x => !string.IsNullOrEmpty(x.Name))
            .WithMessage("Client name must be between 2-40 characters in length");
    }
}
