using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationRepository
{
    Organization Add(Organization org);
    List<Organization> GetByUserId(string userId);
    Organization? GetByUserIdAndOrganizationId(Guid organizationId, string userId);
}