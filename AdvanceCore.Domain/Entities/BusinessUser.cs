using System.ComponentModel.DataAnnotations;

namespace AdvanceCore.Domain.Entities;

public class BusinessUser
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid BusinessId { get; set; }
    [Required]
    public Business Business { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}