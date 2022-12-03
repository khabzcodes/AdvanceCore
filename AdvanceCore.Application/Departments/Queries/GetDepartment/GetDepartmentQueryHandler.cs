using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Queries.GetDepartment;

public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, ErrorOr<DepartmentResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IDepartmentsRepository _departmentsRepository;

    public GetDepartmentQueryHandler(
        IOrganizationRepository organizationRepository, 
        IDepartmentsRepository departmentsRepository)
    {
        _organizationRepository = organizationRepository;
        _departmentsRepository = departmentsRepository;
    }

    public async Task<ErrorOr<DepartmentResponse>> Handle(GetDepartmentQuery query, CancellationToken cancellationToken)
    {
        Organization? organization = _organizationRepository.GetById(query.OrganizationId);
        if (organization == null) return OrganizationErrors.OrganizationNotFound;

        Department? department = _departmentsRepository.GetByIdAndOrganizationId(query.DepartmentId, organization.Id);
        if (department == null) return DepartmentErrors.DepartmentNotFound;

        return await Task.FromResult(new DepartmentResponse(department));
    }
}
