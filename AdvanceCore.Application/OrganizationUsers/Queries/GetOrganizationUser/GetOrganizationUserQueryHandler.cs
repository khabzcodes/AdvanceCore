using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.OrganizationUsers.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUser;

public class GetOrganizationUserQueryHandler : IRequestHandler<GetOrganizationUserQuery, ErrorOr<OrganizationUserResponse>>
{
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public GetOrganizationUserQueryHandler(IOrganizationUserRepository organizationUserRepository)
    {
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<OrganizationUserResponse>> Handle(GetOrganizationUserQuery query, CancellationToken cancellationToken)
    {
        OrganizationUser? organizationUser = _organizationUserRepository.GetByIdAndOrganizationId(query.organizationUserId, query.organizationId);

        if (organizationUser is null) return OrganizationUserErrors.OrganizationUserNotFound;

        return await Task.FromResult(new OrganizationUserResponse(organizationUser));
    }
}