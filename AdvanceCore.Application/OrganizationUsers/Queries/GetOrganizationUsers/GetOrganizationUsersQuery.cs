using AdvanceCore.Application.OrganizationUsers.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUsers;

public record GetOrganizationUsersQuery(
    Guid organizationId,
    string userId
) : IRequest<ErrorOr<OrganizationUsersResponse>>;