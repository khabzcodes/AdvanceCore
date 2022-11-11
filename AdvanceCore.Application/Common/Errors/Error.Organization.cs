using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class OrganizationErrors
{
    public static Error OrganizationNotFound => Error.NotFound(
            code: "Organization.OrganizationNotFound",
            description: "Organization not found");
}