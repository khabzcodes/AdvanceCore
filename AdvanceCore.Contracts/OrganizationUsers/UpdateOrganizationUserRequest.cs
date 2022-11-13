namespace AdvanceCore.Contracts.OrganizationUsers;

public record UpdateOrganizationUserRequest(
    Guid organizationId,
    Guid organizationUserId,
    string primaryContactNumber,
    string secondaryContactNumber
);