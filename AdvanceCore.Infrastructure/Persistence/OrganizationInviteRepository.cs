using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;

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
}