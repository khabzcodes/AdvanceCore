using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.OrganizationUsers.Common;
using AdvanceCore.Application.Persistence;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.OrganizationUsers.Commands.UpdateOrganizationUser;

public class UpdateOrganizationUserCommandHandler : IRequestHandler<UpdateOrganizationUserCommand, ErrorOr<OrganizationUserResponse>>
{
    private readonly IOrganizationUserRepository _organizationUserRepository;

    public UpdateOrganizationUserCommandHandler(IOrganizationUserRepository organizationUserRepository)
    {
        _organizationUserRepository = organizationUserRepository;
    }

    public async Task<ErrorOr<OrganizationUserResponse>> Handle(UpdateOrganizationUserCommand command, CancellationToken cancellationToken)
    {
        var organizationUser = _organizationUserRepository.GetByIdAndOrganizationId(command.organizationUserId, command.organizationId);

        if (organizationUser is null) return OrganizationUserErrors.OrganizationUserNotFound;

        organizationUser.PrimaryContactNumber = command.primaryContactNumber;
        organizationUser.SecondaryContactNumber = command.secondaryPrimaryNumber;

        _organizationUserRepository.Update(organizationUser);

        return await Task.FromResult(new OrganizationUserResponse(organizationUser));
    }
}