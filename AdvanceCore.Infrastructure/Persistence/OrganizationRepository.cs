using System.Linq;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceCore.Infrastructure.Persistence;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Organization Add(Organization org)
    {
        _context.Organizations.Add(org);
        _context.SaveChanges();

        return org;
    }

    public List<Organization> GetByUserId(string userId)
    {
        return _context.Organizations.Include(x => x.OrganizationUsers).Where(x => x.OrganizationUsers.Any(x => x.UserId == userId)).ToList();
    }
}