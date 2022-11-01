using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class OrganizationUser
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid OrganizationId { get; set; }
    [Required]
    public Organization Organization { get; set; } = null!;

    [Required]
    public Guid OrganizationUserRoleId { get; set; }
    [Required]
    public OrganizationUserRole OrganizationUserRole { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}