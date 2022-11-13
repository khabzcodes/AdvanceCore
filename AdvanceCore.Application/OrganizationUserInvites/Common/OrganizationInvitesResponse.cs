using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.OrganizationUserInvites.Common;

public record OrganizationInvitesResponse(
    List<OrganizationInvite> organizationInvites
);