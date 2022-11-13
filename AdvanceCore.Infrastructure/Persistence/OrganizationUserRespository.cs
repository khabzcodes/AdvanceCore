using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceCore.Infrastructure.Persistence;

public class OrganizationUserRepository : IOrganizationUserRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizationUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public OrganizationUser Add(OrganizationUser organizationUser)
    {
        _context.OrganizationUsers.Add(organizationUser);
        _context.SaveChanges();

        return organizationUser;
    }

    public OrganizationUser? GetByIdAndOrganizationId(Guid organizationUserId, Guid organizationId)
    {
        return _context.OrganizationUsers.FirstOrDefault(ou => ou.OrganizationId == organizationId && ou.Id == organizationUserId);
    }

    public List<OrganizationUser> GetByOrganizationId(Guid organizationId)
    {
        return _context.OrganizationUsers.Where(ou => ou.OrganizationId == organizationId).ToList();
    }

    public OrganizationUser? GetByOrganizationIdAndEmail(Guid organizationId, string email)
    {
        return _context.OrganizationUsers.FirstOrDefault(x => x.OrganizationId == organizationId && x.Email == email);
    }
}