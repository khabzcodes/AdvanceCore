namespace AdvanceCore.Contracts.OrganizationUsers;

public record GetOrganizationUserRequest(
    Guid organizationId,
    Guid organizationUserId
);