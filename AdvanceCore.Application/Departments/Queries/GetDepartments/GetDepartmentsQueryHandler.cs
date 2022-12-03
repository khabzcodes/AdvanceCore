using AdvanceCore.Application.Departments.Common;
using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AdvanceCore.Application.Departments.Queries.GetDepartments;

public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, ErrorOr<DepartmentsResponse>>
{
    private readonly IDepartmentsRepository _departmentsRepository;

    public GetDepartmentsQueryHandler(IDepartmentsRepository departmentsRepository)
    {
        _departmentsRepository = departmentsRepository;
    }

    public async Task<ErrorOr<DepartmentsResponse>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
    {
        List<Department> departments = _departmentsRepository.GetAllByOrganizationId(request.OrganizationId);

        return await Task.FromResult(new DepartmentsResponse(departments));
    }
}
