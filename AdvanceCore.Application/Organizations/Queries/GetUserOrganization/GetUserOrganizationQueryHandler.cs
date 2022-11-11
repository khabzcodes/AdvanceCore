using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Persistence;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganization;

public class GetUserOrganizationQueryHandler : IRequestHandler<GetUserOrganizationQuery, ErrorOr<OrganizationResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;

    public GetUserOrganizationQueryHandler(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task<ErrorOr<OrganizationResponse>> Handle(GetUserOrganizationQuery query, CancellationToken cancellationToken)
    {
        var organization = _organizationRepository.GetByUserIdAndOrganizationId(query.organizationId, query.userId);

        if (organization is null) return OrganizationErrors.OrganizationNotFound;

        return await Task.FromResult(new OrganizationResponse(organization));
    }
}