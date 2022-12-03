using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Domain.Entities;

public class Department
{
    public Department(Guid id, Guid organizationId, string name, string? description, DateTime createdAtUtc)
    {
        Id = id;
        OrganizationId = organizationId;
        Name = name;
        Description = description;
        CreatedAtUtc = createdAtUtc;
    }

    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; }

    public static Department Create(Guid id, Guid organizationId, string name, string? description, DateTime createdAtUtc)
    { 
        return new Department(id, organizationId, name, description, createdAtUtc);
    }
}
