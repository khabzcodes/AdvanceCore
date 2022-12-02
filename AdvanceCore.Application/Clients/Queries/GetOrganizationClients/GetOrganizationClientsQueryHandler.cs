using AdvanceCore.Application.Clients.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClients;

public class GetOrganizationClientsQueryHandler : IRequestHandler<GetOrganizationClientsQuery, ErrorOr<ClientsResponse>>
{
    private readonly IClientsRepository _clientsRepository;

    public GetOrganizationClientsQueryHandler(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task<ErrorOr<ClientsResponse>> Handle(GetOrganizationClientsQuery query, CancellationToken cancellationToken)
    {
        List<Client> clients = _clientsRepository.GetAllByOrganizationId(query.OrganizationId);

        return await Task.FromResult(new ClientsResponse(clients));
    }
}
