using AdvanceCore.Application.Organizations.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Organizations.Queries.GetUserOrganizations;

public record GetUserOrganizationsQuery(
    string userId
) : IRequest<ErrorOr<OrganizationsResponse>>;