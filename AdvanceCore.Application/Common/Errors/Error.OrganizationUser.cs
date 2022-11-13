using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class OrganizationUserErrors
{
    public static Error OrganizationUserAlreadyExist => Error.Conflict(
            code: "OrganizationUser.OrganizationUserAlreadyExist",
            description: "User already exist in this organization");

    public static Error OrganizationUserNotFound => Error.NotFound(
        code: "OrganizationUser.OrganizationUserNotFound",
        description: "Organization user not found"
    );
}