using AdvanceCore.Application.OrganizationInvites.Common;
using AdvanceCore.Application.OrganizationUsers.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Application.OrganizationUsers.Commands.AddOrganizationUser;

public class AddOrganizationUserCommandHandler : IRequestHandler<AddOrganizationUserCommand, ErrorOr<OrganizationInviteResponse>>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IOrganizationInviteRepository _organizationInviteRepository;

    public AddOrganizationUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        IOrganizationInviteRepository organizationInviteRepository)
    {
        _userManager = userManager;
        _organizationInviteRepository = organizationInviteRepository;
    }

    public async Task<ErrorOr<OrganizationInviteResponse>> Handle(AddOrganizationUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);

        OrganizationInvite createOrganizationInvite = OrganizationInvite.Create(request.email, request.organizationId);
        OrganizationInvite organizationInvite = _organizationInviteRepository.Add(createOrganizationInvite);

        return await Task.FromResult(
            new OrganizationInviteResponse(
                organizationInvite.Id,
                organizationInvite.OrganizationId,
                organizationInvite.Email,
                organizationInvite.CreatedAt));
    }
}