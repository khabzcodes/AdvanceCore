using FluentResults;
using MediatR;

namespace AdvanceCore.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string firstName,
    string lastName,
    string email,
    string password,
    string companyName,
    string companyEmail
) : IRequest<AuthenticationResult>;