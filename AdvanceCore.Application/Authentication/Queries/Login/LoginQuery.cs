using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Authentication.Queries.Login;

public record LoginQuery(
    string email,
    string password
) : IRequest<ErrorOr<AuthResponse>>;