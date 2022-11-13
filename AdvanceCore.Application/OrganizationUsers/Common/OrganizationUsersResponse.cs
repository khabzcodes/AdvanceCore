using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.OrganizationUsers.Common;

public record OrganizationUsersResponse(
    List<OrganizationUser> organizationUsers
);