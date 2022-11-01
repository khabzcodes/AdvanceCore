using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class OrganizationUserRole
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Name { get; set; } = string.Empty;
}