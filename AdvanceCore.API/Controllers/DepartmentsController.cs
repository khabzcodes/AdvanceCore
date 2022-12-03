using AdvanceCore.Application.Departments.Commands.CreateDepartment;
using AdvanceCore.Application.Departments.Commands.UpdateDepartment;
using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Application.Departments.Queries.GetDepartment;
using AdvanceCore.Application.Departments.Queries.GetDepartments;
using AdvanceCore.Contracts.Departments;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCore.API.Controllers
{
    [Authorize]
    [Route("api/departments")]
    public class DepartmentsController : ApiController
    {
        private readonly ISender _mediator;
        public DepartmentsController(ISender mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get organization departments
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("getDepartments")]
        public async Task<IActionResult> Get( 
            [FromQuery] Guid organizationId, 
            CancellationToken cancellationToken)
        {
            GetDepartmentsQuery query = new(organizationId);

            ErrorOr<DepartmentsResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error));
        }

        [HttpGet("getDepartment")]
        public async Task<IActionResult> Get(
            [FromQuery] Guid departmentId, 
            [FromQuery] Guid organizationId, 
            CancellationToken cancellationToken)
        {
            GetDepartmentQuery query = new(departmentId, organizationId);

            ErrorOr<DepartmentResponse> result = await _mediator.Send(query, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error));
        }

        /// <summary>
        /// Add organization department
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Add(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            CreateDepartmentCommand command = new(request.OrganizationId, request.Name, request.Description);

            ErrorOr<DepartmentResponse> result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                result => Ok(result), 
                error => Problem(error));
        }

        /// <summary>
        /// Update organization department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromQuery] Guid departmentId, 
            UpdateDepartmentRequest request, 
            CancellationToken cancellationToken)
        {
            UpdateDepartmentCommand command = new(departmentId, request.OrganizationId, request.Name, request.Description);

            ErrorOr<DepartmentResponse> result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                result => Ok(result),
                error => Problem(error));
        }
    }
}
