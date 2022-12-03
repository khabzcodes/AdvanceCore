using AdvanceCore.Application.Departments.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(
    Guid OrganizationId,
    string Name,
    string? Description
    ): IRequest<ErrorOr<DepartmentResponse>>;
