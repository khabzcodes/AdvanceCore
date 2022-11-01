using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationUserRepository
{
    OrganizationUser AddOrganizationUser(OrganizationUser orgUser);
}