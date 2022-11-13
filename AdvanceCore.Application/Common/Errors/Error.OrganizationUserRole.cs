using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class OrganizationUserRoleErrors
{
    public static Error OrganizationUserRoleNotFound => Error.Validation(
        code: "OrganizationUserRole.OrganizationUserRoleNotFound",
        description: "Organization user role not found"
    );
}