namespace AdvanceCore.Domain.Entities;

public class OrganizationInvite
{
    public OrganizationInvite(
        Guid organizationId,
        string email,
        string role,
        string createdById)
    {
        OrganizationId = organizationId;
        Email = email;
        Role = role;
        CreatedById = createdById;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; }
    public string Role { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;
    public string CreatedById { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public static OrganizationInvite Create(
        Guid organizationId,
        string email,
        string role,
        string createdById)
    {
        OrganizationInvite organizationInvite = new OrganizationInvite(
            organizationId,
            email,
            role,
            createdById
        );

        return organizationInvite;
    }
}