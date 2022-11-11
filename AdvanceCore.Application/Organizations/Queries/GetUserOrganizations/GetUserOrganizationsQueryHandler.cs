using AdvanceCore.Application.Organizations.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganizations;

public class GetUserOrganizationsQueryHandler : IRequestHandler<GetUserOrganizationsQuery, ErrorOr<OrganizationsResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;

    public GetUserOrganizationsQueryHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<ErrorOr<OrganizationsResponse>> Handle(GetUserOrganizationsQuery query, CancellationToken cancellationToken)
    {
        List<Organization> organizations = _organizationRepository.GetByUserId(query.userId);

        return await Task.FromResult(new OrganizationsResponse(organizations));
    }
}

