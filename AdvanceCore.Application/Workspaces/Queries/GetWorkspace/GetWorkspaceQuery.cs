using AdvanceCore.Application.Workspaces.Common;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Workspaces.Queries.GetWorkspace;
public record GetWorkspaceQuery(
    string UserId
    ) : IRequest<ErrorOr<WorkspaceResponse>>;
