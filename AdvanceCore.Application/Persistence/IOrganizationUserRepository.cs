using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationUserRepository
{
    OrganizationUser Add(OrganizationUser organizationUser);
    void Update(OrganizationUser organizationUser);
    OrganizationUser? GetByOrganizationIdAndEmail(Guid organizationId, string email);
    OrganizationUser? GetByIdAndOrganizationId(Guid organizationUserId, Guid organizationId);
    List<OrganizationUser> GetByOrganizationId(Guid organizationId);
}