using AdvanceCore.Application.OrganizationUserInvites.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUserInvites.Queries.GetOrganizationInvites;

public class OrganizationInvitesQueryHandler : IRequestHandler<OrganizationInvitesQuery, ErrorOr<OrganizationInvitesResponse>>
{
    private readonly IOrganizationInviteRepository _organizationInviteRepository;

    public OrganizationInvitesQueryHandler(IOrganizationInviteRepository organizationInviteRepository)
    {
        _organizationInviteRepository = organizationInviteRepository;
    }

    public async Task<ErrorOr<OrganizationInvitesResponse>> Handle(OrganizationInvitesQuery query, CancellationToken cancellationToken)
    {
        List<OrganizationInvite> organizationInvites = _organizationInviteRepository.GetByOrganizationId(query.organizationId);

        return await Task.FromResult(new OrganizationInvitesResponse(organizationInvites));
    }
}