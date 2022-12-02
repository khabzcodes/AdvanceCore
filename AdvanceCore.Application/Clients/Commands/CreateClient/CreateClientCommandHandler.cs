using AdvanceCore.Application.Clients.Common;
using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Clients.Commands.CreateClient;

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ErrorOr<ClientResponse>>
{
    private readonly IClientsRepository _clientsRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public CreateClientCommandHandler(
        IClientsRepository clientsRepository, 
        IOrganizationRepository organizationRepository
        )
    {
        _clientsRepository = clientsRepository;
        _organizationRepository = organizationRepository;
    }

    public async Task<ErrorOr<ClientResponse>> Handle(CreateClientCommand command, CancellationToken cancellationToken)
    {
        Organization? organization = _organizationRepository.GetByUserIdAndOrganizationId(
            command.OrganizationId,
            command.UserId
            );

        if (organization is null) return OrganizationUserErrors.OrganizationUserNotFound;

        //TODO: Check role
        Client client = Client.Create(
            Guid.NewGuid(), 
            command.OrganizationId, 
            command.Name, 
            command.Description, 
            DateTime.UtcNow);

        _clientsRepository.Add(client);

        return await Task.FromResult(new ClientResponse(client));
    }
}
