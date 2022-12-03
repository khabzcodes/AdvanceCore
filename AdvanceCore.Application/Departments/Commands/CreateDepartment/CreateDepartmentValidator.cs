using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Departments.Commands.CreateDepartment;

public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentValidator()
    {
        RuleFor(c => c.OrganizationId).NotEmpty().WithMessage("Organization id is required");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Department name is required");
    }
}
