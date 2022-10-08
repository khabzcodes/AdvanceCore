using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IBusinessRepository
{
    Business AddBusiness(Business business);
}