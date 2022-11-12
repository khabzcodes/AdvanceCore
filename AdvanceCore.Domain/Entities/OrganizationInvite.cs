namespace AdvanceCore.Domain.Entities;

public class OrganizationInvite
{
    public OrganizationInvite(string email, Guid organizationId)
    {
        Email = email;
        OrganizationId = organizationId;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public static OrganizationInvite Create(string email, Guid organizationId)
    {
        OrganizationInvite organizationInvite = new OrganizationInvite(
            email,
            organizationId
        );

        return organizationInvite;
    }
}