using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganization;

public record GetUserOrganizationQuery(
    Guid organizationId,
    string userId
) : IRequest<ErrorOr<OrganizationResponse>>;