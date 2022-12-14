using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Infrastructure.Persistence;

public class ClientsRepository : IClientsRepository
{
    private readonly ApplicationDbContext _context;

    public ClientsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Client client)
    {
        _context.Clients.Add(client);
        _context.SaveChanges();
    }

    public List<Client> GetAllByOrganizationId(Guid OrganizationId)
    {
        return _context.Clients.Where(c => c.OrganizationId == OrganizationId).ToList();
    }

    public Client? GetByIdAndOrganizationId(Guid id, Guid organizationId)
    {
        return _context.Clients.FirstOrDefault(x => x.Id == id && x.OrganizationId == organizationId);
    }
}
