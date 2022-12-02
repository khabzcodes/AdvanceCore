using AdvanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Clients.Common;

public record ClientsResponse(
    List<Client> Clients
    );
