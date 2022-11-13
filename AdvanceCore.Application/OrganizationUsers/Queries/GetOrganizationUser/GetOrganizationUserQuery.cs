using AdvanceCore.Application.OrganizationUsers.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUser;

public record GetOrganizationUserQuery(
    Guid organizationUserId,
    Guid organizationId
) : IRequest<ErrorOr<OrganizationUserResponse>>;