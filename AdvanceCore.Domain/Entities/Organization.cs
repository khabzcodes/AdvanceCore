using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class Organization
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = string.Empty;

    public List<OrganizationUser> OrganizationsUsers { get; set; } = null!;

    [Required]
    public string CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}