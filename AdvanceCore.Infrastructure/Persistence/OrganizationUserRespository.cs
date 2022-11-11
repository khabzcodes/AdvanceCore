using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;

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
}