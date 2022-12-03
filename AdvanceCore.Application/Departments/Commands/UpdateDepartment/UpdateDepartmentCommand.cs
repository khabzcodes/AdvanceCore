using AdvanceCore.Application.Departments.Common;
using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Application.Departments.Commands.UpdateDepartment;

public record UpdateDepartmentCommand(
    [JsonProperty("departmentId")]
    Guid DepartmentId,
    [JsonProperty("organizationId")]
    Guid OrganizationId,
    [JsonProperty("name")]
    string Name,
    [JsonProperty("description")]
    string? Description
    ): IRequest<ErrorOr<DepartmentResponse>>;
