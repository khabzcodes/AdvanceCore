using AdvanceCore.Application.OrganizationUsers.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Commands.UpdateOrganizationUser;

public record UpdateOrganizationUserCommand(
    Guid organizationId,
    Guid organizationUserId,
    string userId,
    string primaryContactNumber,
    string secondaryPrimaryNumber
) : IRequest<ErrorOr<OrganizationUserResponse>>;