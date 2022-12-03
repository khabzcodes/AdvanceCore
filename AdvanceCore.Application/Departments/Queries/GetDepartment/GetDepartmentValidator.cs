using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Departments.Queries.GetDepartment;

public class GetDepartmentValidator : AbstractValidator<GetDepartmentQuery>
{
	public GetDepartmentValidator()
	{
		RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Department id is required");
		RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("Organization id is required");
	}
}
