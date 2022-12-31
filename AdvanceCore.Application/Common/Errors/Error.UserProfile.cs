using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class UserProfileErrors
{
    public static Error UserProfileNotFound => Error.NotFound(
        code: "UserProfileNotFound.NotFound",
        description: "User not found"
        );
}
