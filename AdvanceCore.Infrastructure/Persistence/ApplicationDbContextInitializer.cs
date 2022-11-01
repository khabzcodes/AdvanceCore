using AdvanceCore.Domain.Constants;
using AdvanceCore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AdvanceCore.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    public ApplicationDbContextInitializer(
        ApplicationDbContext context,
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ILogger<ApplicationDbContextInitializer> logger)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while migrating data");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedUserRoles();
            await TrySeedOrganizationUserRoles();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding data to database");
            throw;
        }
    }

    public async Task TrySeedUserRoles()
    {
        try
        {
            if (_roleManager.Roles.All(x => x.Name != Constants.AdminRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(Constants.AdminRole));
            }

            if (_roleManager.Roles.All(x => x.Name != Constants.UserRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(Constants.UserRole));
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding user role data");
            throw;
        }
    }

    public async Task TrySeedOrganizationUserRoles()
    {
        try
        {
            if (_context.OrganizationUserRoles.All(x => x.Name != Constants.Administrator))
            {
                OrganizationUserRole organizationUserRole = new()
                {
                    Name = Constants.Administrator
                };
                _context.OrganizationUserRoles.Add(organizationUserRole);
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding organization user roles");
            throw;
        }
    }
}