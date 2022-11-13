using AdvanceCore.Application.Authentication;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.AcceptOrganizationInvite;

public record AcceptOrganizationInviteCommand(
    Guid organizationInviteId,
    string firstName,
    string lastName,
    string email,
    string password
) : IRequest<ErrorOr<AuthResponse>>;