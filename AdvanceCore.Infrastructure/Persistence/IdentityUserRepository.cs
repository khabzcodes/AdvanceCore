using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Infrastructure.Persistence;

public class IdentityUserRepository : IIdentityUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityUserRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> AssignRoleToUserAsync(ApplicationUser user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public string? GetUserRoleAsync(ApplicationUser user)
    {
        return _userManager.GetRolesAsync(user).Result.FirstOrDefault();
    }

    public async Task<IdentityResult> CreateApplicationUser(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<ApplicationUser?> GetApplicationUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}