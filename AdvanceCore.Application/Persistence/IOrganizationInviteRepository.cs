using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationInviteRepository
{
    OrganizationInvite Add(OrganizationInvite organizationInvite);
    OrganizationInvite? GetByOrganizationIdAndEmail(Guid organizationId, string email);
    List<OrganizationInvite> GetByOrganizationId(Guid organizationId);
}