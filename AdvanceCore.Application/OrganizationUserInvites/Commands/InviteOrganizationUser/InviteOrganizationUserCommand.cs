using AdvanceCore.Application.OrganizationUserInvites.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUserInvites.Commands.InviteOrganizationUser;

public record InviteOrganizationUserCommand(
    Guid organizationId,
    string email,
    string role,
    string createdById
) : IRequest<ErrorOr<OrganizationInviteResponse>>;