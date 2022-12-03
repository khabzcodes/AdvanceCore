using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;
public static class DepartmentErrors
{
    public static Error DepartmentNotFound => Error.NotFound(
        code: "Department.DepartmentNotFound",
        description: "Department not found"
        );
}
