using AdvanceCore.Application.Persistence;
using AdvanceCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCore.Infrastructure.Persistence;

public class DepartmentsRepository : IDepartmentsRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Department department)
    {
        _context.Departments.Add(department);
        _context.SaveChanges();
    }

    public List<Department> GetAllByOrganizationId(Guid organizationId)
    {
        return _context.Departments.Where(x => x.OrganizationId == organizationId).ToList();
    }

    public Department? GetById(Guid id)
    {
        Department? department = _context.Departments.FirstOrDefault(x => x.Id == id);

        return department;
    }

    public Department? GetByIdAndOrganizationId(Guid departmentId, Guid organizationId)
    {
        return _context.Departments.FirstOrDefault(d => d.Id == departmentId && d.OrganizationId == organizationId);
    }

    public void Update(Department department)
    {
        _context.Update(department);
        _context.SaveChanges();
    }
}
