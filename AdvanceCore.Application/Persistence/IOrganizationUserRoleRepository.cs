using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationUserRoleRepository
{
    OrganizationUserRole? GetByName(string name);
}