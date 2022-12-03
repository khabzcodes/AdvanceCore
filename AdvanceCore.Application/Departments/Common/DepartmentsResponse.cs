using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Departments.Common;

public record DepartmentsResponse(
    List<Department> Departments
    );
