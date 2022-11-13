using AdvanceCore.Application.OrganizationUserInvites.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUserInvites.Queries.GetOrganizationInvites;

public record OrganizationInvitesQuery(
    Guid organizationId
) : IRequest<ErrorOr<OrganizationInvitesResponse>>;