using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Infrastructure.Persistence;

public class OrganizationUserRoleRepository : IOrganizationUserRoleRepository
{
    private readonly ApplicationDbContext _context;

    public OrganizationUserRoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public OrganizationUserRole? GetByName(string name)
    {
        return _context.OrganizationUserRoles.FirstOrDefault(x => x.Name.ToUpper() == name.ToUpper());
    }
}