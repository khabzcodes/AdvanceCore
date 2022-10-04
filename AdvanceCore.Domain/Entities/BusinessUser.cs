using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class BusinessUser
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public ApplicationUser ApplicationUser { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}