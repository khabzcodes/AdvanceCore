using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class OrganizationUserRole
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}