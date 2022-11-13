using AdvanceCore.Application.OrganizationUsers.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Queries.GetOrganizationUsers;

public class GetOrganizationUsersQueryHandler : IRequestHandler<GetOrganizationUsersQuery, ErrorOr<OrganizationUsersResponse>>
{
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public GetOrganizationUsersQueryHandler(IOrganizationUserRepository organizationUserRepository)
    {
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<OrganizationUsersResponse>> Handle(GetOrganizationUsersQuery query, CancellationToken cancellationToken)
    {
        List<OrganizationUser> organizationUsers = _organizationUserRepository.GetByOrganizationId(query.organizationId);

        return await Task.FromResult(new OrganizationUsersResponse(organizationUsers));
    }
}