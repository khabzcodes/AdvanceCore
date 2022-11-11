using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Organizations.Common;

public record OrganizationsResponse(
    List<Organization> organizations
);