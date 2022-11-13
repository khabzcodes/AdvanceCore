using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class OrganizationUserInviteErrors
{
    public static Error InviteAlreadySent => Error.Conflict(
            code: "OrganizationUserInvite.InviteAlreadySent",
            description: "An invite has already been sent");

    public static Error InviteNotFound => Error.NotFound(
        code: "OrganizationUserInvite.InviteNotFound",
        description: "Organization invitation not found"
    );
}