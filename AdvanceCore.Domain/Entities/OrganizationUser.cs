using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCore.Domain.Entities;

public class OrganizationUser
{
    public OrganizationUser(
        Guid organizationId,
        string userId,
        string email,
        string role,
        string? primaryContactNumber,
        string? secondaryContactNumber)
    {
        OrganizationId = organizationId;
        UserId = userId;
        Email = email;
        Role = role;
        PrimaryContactNumber = primaryContactNumber;
        SecondaryContactNumber = secondaryContactNumber;
    }

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrganizationId { get; set; }

    public string UserId { get; set; }

    public string? Email { get; set; }

    public string? PrimaryContactNumber { get; set; }

    public string? SecondaryContactNumber { get; set; }

    public string Role { get; set; }

    public bool IsActive { get; set; } = false;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public static OrganizationUser Create(
        Guid organizationId,
        string userId,
        string email,
        string role,
        string? primaryContactNumber,
        string? secondaryContactNumber)
    {
        OrganizationUser organizationUser = new OrganizationUser(
            organizationId,
            userId,
            email,
            role,
            primaryContactNumber,
            secondaryContactNumber);

        return organizationUser;
    }
}