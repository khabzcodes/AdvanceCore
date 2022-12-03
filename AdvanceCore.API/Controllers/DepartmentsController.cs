using AdvanceCore.Application.Departments.Commands.CreateDepartment;
using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Contracts.Departments;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers
{
    [Route("api/departments")]
    public class DepartmentsController : ApiController
    {
        private readonly ISender _mediator;
        public DepartmentsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Add(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            CreateDepartmentCommand command = new(request.OrganizationId, request.Name, request.Description);

            ErrorOr<DepartmentResponse> result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error));
        }
    }
}
