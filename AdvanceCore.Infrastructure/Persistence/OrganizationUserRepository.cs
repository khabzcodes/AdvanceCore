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

    public OrganizationUser AddOrganizationUser(OrganizationUser orgUser)
    {
        _context.OrganizationUsers.Add(orgUser);
        _context.SaveChanges();

        return orgUser;
    }
}