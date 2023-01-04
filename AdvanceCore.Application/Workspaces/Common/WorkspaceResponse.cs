using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Workspaces.Common;

public record WorkspaceResponse(
    ApplicationUser User,
    Organization Organization
    );
