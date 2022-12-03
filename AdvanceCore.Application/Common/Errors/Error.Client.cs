using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class ClientErrors
{
    public static Error ClientNotFound => Error.NotFound(
        code: "ClientNotFound.NotFound",
        description: "Client not found"
        );
}
