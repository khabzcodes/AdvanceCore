using AdvanceCore.Application.Clients.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Clients.Commands.CreateClient;

public record CreateClientCommand(
    Guid OrganizationId,
    string UserId,
    string Name,
    string? Description
    ): IRequest<ErrorOr<ClientResponse>>;
