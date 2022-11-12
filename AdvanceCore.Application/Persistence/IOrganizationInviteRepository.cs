using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IOrganizationInviteRepository
{
    OrganizationInvite Add(OrganizationInvite organizationInvite);
}