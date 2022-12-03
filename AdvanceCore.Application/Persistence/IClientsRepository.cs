using AdvanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Persistence;
public interface IClientsRepository
{
    void Add(Client client);
    Client? GetByIdAndOrganizationId(Guid id, Guid organizationId);
    List<Client> GetAllByOrganizationId(Guid OrganizationId);
}
