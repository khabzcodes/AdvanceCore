namespace AdvanceCore.Contracts.OrganizationInvite;

public record InviteOrganizationUserRequest(
    Guid organizationId,
    string email,
    string role
);