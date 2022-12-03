using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IDepartmentsRepository
{
    void Add(Department department);
    void Update(Department department);
    Department? GetById(Guid id);
}
