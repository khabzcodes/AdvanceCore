namespace AdvanceCore.Application.OrganizationInvites.Common;

public record OrganizationInviteResponse(
    Guid organizationInviteId,
    Guid organizationId,
    string email,
    DateTime createdAt
);