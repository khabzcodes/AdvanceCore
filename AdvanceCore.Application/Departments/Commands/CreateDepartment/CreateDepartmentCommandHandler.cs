using AdvanceCore.Application.Common.Errors;
using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Commands.CreateDepartment;
public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, ErrorOr<DepartmentResponse>>
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IDepartmentsRepository _departmentsRepository;

    public CreateDepartmentCommandHandler(
        IOrganizationRepository organizationRepository, 
        IDepartmentsRepository departmentsRepository)
    {
        _organizationRepository = organizationRepository;
        _departmentsRepository = departmentsRepository;
    }

    public async Task<ErrorOr<DepartmentResponse>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Organization? organization = _organizationRepository.GetById(request.OrganizationId);
        if (organization == null) return OrganizationErrors.OrganizationNotFound;

        Department department = Department.Create(
            Guid.NewGuid(),
            organization.Id,
            request.Name,
            request.Description,
            DateTime.UtcNow
            );
        
        _departmentsRepository.Add(department);

        return await Task.FromResult(new DepartmentResponse(department));
    }
}
