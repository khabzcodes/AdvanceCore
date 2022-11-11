using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationUserRepository
{
    OrganizationUser Add(OrganizationUser organizationUser);
}