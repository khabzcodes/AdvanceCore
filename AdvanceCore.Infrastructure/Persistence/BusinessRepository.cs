using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Infrastructure.Persistence;

public class BusinessRepository : IBusinessRepository
{
    private readonly ApplicationDbContext _context;

    public BusinessRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Business AddBusiness(Business business)
    {
        _context.Businesses.Add(business);
        _context.SaveChanges();

        return business;
    }
}