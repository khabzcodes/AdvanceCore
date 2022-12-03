using AdvanceCore.Application.Departments.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Departments.Queries.GetDepartments;

public record GetDepartmentsQuery(
    Guid OrganizationId
    ) : IRequest<ErrorOr<DepartmentsResponse>>;
