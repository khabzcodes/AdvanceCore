using AdvanceCore.Application.Departments.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Queries.GetDepartment;

public record GetDepartmentQuery(
    Guid DepartmentId,
    Guid OrganizationId
    ) : IRequest<ErrorOr<DepartmentResponse>>;
