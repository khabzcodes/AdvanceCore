namespace AdvanceCore.Contracts.OrganizationUsers;

public record AcceptOrganizationInviteRequest(
    Guid organizationInviteId,
    string firstName,
    string lastName,
    string email,
    string password
);