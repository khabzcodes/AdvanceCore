using AdvanceCore.Domain.Entities;
using Newtonsoft.Json;

namespace AdvanceCore.Application.Departments.Common;

public record DepartmentResponse(
    [JsonProperty("department")]
    Department Department
    );
