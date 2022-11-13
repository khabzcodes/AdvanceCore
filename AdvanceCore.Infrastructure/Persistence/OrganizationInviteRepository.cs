using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceCore.Infrastructure.Persistence;

public class OrganizationInviteRepository : IOrganizationInviteRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizationInviteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public OrganizationInvite Add(OrganizationInvite organizationInvite)
    {
        _context.OrganizationInvites.Add(organizationInvite);
        _context.SaveChanges();

        return organizationInvite;
    }

    public OrganizationInvite? GetById(Guid organizationInviteId)
    {
        return _context.OrganizationInvites.FirstOrDefault(x => x.Id == organizationInviteId);
    }

    public List<OrganizationInvite> GetByOrganizationId(Guid organizationId)
    {
        return _context.OrganizationInvites.Include(x => x.Organization)
            .ThenInclude(x => x.OrganizationUsers)
            .Where(oi => oi.OrganizationId == organizationId).ToList();
    }

    public OrganizationInvite? GetByOrganizationIdAndEmail(Guid organizationId, string email)
    {
        return _context.OrganizationInvites
            .Include(x => x.Organization)
            .FirstOrDefault(x => x.OrganizationId == organizationId && x.Email == email);
    }

    public void Remove(OrganizationInvite organizationInvite)
    {
        _context.OrganizationInvites.Remove(organizationInvite);
        _context.SaveChanges();
    }
}