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
}
