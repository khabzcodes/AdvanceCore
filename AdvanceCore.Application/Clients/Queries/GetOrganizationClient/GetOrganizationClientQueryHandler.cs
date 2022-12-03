using AdvanceCore.Application.Clients.Common;
using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Clients.Queries.GetOrganizationClient;

public class GetOrganizationClientQueryHandler : IRequestHandler<GetOrganizationClientQuery, ErrorOr<ClientResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IClientsRepository _clientsRepository;

    public GetOrganizationClientQueryHandler(
        IOrganizationRepository organizationRepository, 
        IClientsRepository clientsRepository)
    {
        _organizationRepository = organizationRepository;
        _clientsRepository = clientsRepository;
    }

    public async Task<ErrorOr<ClientResponse>> Handle(GetOrganizationClientQuery query, CancellationToken cancellationToken)
    {
        Organization? organization = _organizationRepository.GetById(query.OrganizationId);
        if (organization == null) return OrganizationErrors.OrganizationNotFound;

        Client? client = _clientsRepository.GetByIdAndOrganizationId(query.ClientId, organization.Id);
        if (client == null) return ClientErrors.ClientNotFound;

        return await Task.FromResult(new ClientResponse(client));
    }
}
