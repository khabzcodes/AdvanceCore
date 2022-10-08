using AdvanceCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.Persistence;

public interface IIdentityUserRepository
{
    Task<ApplicationUser?> GetApplicationUserByEmailAsync(string email);
    Task<IdentityResult> CreateApplicationUser(ApplicationUser user, string password);
    Task<IdentityResult> AssignRoleToUserAsync(ApplicationUser user, string role);

    string? GetUserRoleAsync(ApplicationUser user);
}