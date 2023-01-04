using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvanceCore.Infrastructure.Persistence;

public class UserProfileRepository : IUserProfileRepository
{
    private readonly ApplicationDbContext _context;
    public UserProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public ApplicationUser? GetById(string userId)
    {
        return _context.Users.FirstOrDefault(x => x.Id == userId);
    }
}