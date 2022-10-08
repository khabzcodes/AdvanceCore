using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Infrastructure.Persistence;

public class BusinessUserRepository : IBusinessUserRepository
{
    private readonly ApplicationDbContext _context;

    public BusinessUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public BusinessUser AddBusinessUser(BusinessUser businessUser)
    {
        _context.BusinessUsers.Add(businessUser);
        _context.SaveChanges();

        return businessUser;
    }
}