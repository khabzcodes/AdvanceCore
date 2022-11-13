using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCore.Domain.Entities;

public class OrganizationUser
{
    public OrganizationUser(
        Guid id,
        Guid organizationId,
        string userId,
        string email,
        string role,
        string? primaryContactNumber,
        string? secondaryContactNumber,
        bool isActive,
        DateTime createdAtUtc)
    {
        Id = id;
        OrganizationId = organizationId;
        UserId = userId;
        Email = email;
        Role = role;
        PrimaryContactNumber = primaryContactNumber;
        SecondaryContactNumber = secondaryContactNumber;
        IsActive = isActive;
        CreatedAtUtc = createdAtUtc;
    }

    [Key]
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string UserId { get; set; }

    public string Email { get; set; }

    public string? PrimaryContactNumber { get; set; }

    public string? SecondaryContactNumber { get; set; }

    public string Role { get; set; }

    public bool IsActive { get; set; } = false;

    public DateTime CreatedAtUtc { get; set; }

    public static OrganizationUser Create(
        Guid id,
        Guid organizationId,
        string userId,
        string email,
        string role,
        string? primaryContactNumber,
        string? secondaryContactNumber,
        bool isActive,
        DateTime createdAtUtc)
    {
        OrganizationUser organizationUser = new OrganizationUser(
            id,
            organizationId,
            userId,
            email,
            role,
            primaryContactNumber,
            secondaryContactNumber,
            isActive,
            createdAtUtc);

        return organizationUser;
    }
}