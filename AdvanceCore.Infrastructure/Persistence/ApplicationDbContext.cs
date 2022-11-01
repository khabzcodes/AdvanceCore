using AdvanceCore.Application.Common.Interface.Data;
using AdvanceCore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvanceCore.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<OrganizationUser> OrganizationUsers { get; set; } = null!;
    public DbSet<OrganizationUserRole> OrganizationUserRoles { get; set; } = null!;
}