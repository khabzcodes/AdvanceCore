using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentValidator()
    {
        RuleFor(c => c.DepartmentId).NotEmpty().WithMessage("Department id is required");
        RuleFor(c => c.OrganizationId).NotEmpty().WithMessage("Organization id is required");
        RuleFor(c => c.Name).NotEmpty().WithMessage("Department name is required");
    }
}
