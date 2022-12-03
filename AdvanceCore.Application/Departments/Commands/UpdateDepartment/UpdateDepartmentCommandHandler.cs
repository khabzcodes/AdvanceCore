using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, ErrorOr<DepartmentResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IDepartmentsRepository _departmentsRepository;

    public UpdateDepartmentCommandHandler(
        IOrganizationRepository organizationRepository, 
        IDepartmentsRepository departmentsRepository)
    {
        _organizationRepository = organizationRepository;
        _departmentsRepository = departmentsRepository;
    }

    public async Task<ErrorOr<DepartmentResponse>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Organization? organization = _organizationRepository.GetById(request.OrganizationId);
        if (organization == null) return OrganizationErrors.OrganizationNotFound;

        Department? department = _departmentsRepository.GetById(request.DepartmentId);
        if (department == null) return DepartmentErrors.DepartmentNotFound;

        department.Name = request.Name;
        department.Description = request.Description;

        _departmentsRepository.Update(department);

        return await Task.FromResult(new DepartmentResponse(department));
    }
}
