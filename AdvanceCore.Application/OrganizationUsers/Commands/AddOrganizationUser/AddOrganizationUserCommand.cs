using AdvanceCore.Application.OrganizationInvites.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Commands.AddOrganizationUser;

public record AddOrganizationUserCommand(
    Guid organizationId,
    string email
) : IRequest<ErrorOr<OrganizationInviteResponse>>;