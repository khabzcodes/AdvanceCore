using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Domain.Entities;
public class Client
{
    public Client(Guid id, Guid organizationId, string name, string? description, DateTime createdAt)
    {
        Id = id;
        OrganizationId = organizationId;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public static Client Create(Guid id, Guid organizationId, string name, string? description, DateTime createdAt)
    {
        return new Client(id, organizationId, name, description, createdAt);
    }
}
