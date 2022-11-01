using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationRepository
{
    Organization AddOrganization(Organization org);
}