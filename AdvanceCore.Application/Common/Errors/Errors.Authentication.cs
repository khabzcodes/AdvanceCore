using ErrorOr;

namespace AdvanceCore.Application.Common.Errors;

public static class CustomErrors
{
    public static class Authentication
    {
        public static Error IncorrectEmailOrPassword => Error.Unexpected(
            code: "User.IncorrectEmailOrPassword",
            description: "Incorrect email/password");
    }
}