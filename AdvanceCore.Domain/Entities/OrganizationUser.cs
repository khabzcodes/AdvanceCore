using System.ComponentModel.DataAnnotations;

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
        bool isDefault,
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
        IsDefault = isDefault;
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

    public bool IsDefault { get; set; }

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
        bool isDefault,
        DateTime createdAtUtc)
    {
        OrganizationUser organizationUser = new(
            id,
            organizationId,
            userId,
            email,
            role,
            primaryContactNumber,
            secondaryContactNumber,
            isActive,
            isDefault,
            createdAtUtc);

        return organizationUser;
    }
}