using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceCore.Domain.Entities;

public class Organization
{
    public Organization(
        Guid id,
        string name,
        string email,
        string creatorId,
        DateTime createdAtUtc)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatorId = creatorId;
        CreatedAtUtc = createdAtUtc;
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string CreatorId { get; set; }

    public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; } = new List<OrganizationUser>();

    public DateTime CreatedAtUtc { get; set; }

    public static Organization Create(
        Guid id,
        string name,
        string email,
        string creatorId,
        DateTime createdAtUtc)
    {
        Organization organization = new Organization(
            id,
            name,
            email,
            creatorId,
            createdAtUtc);

        return organization;
    }
}