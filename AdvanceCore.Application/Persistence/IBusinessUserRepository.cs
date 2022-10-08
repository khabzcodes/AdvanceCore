using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IBusinessUserRepository
{
    BusinessUser AddBusinessUser(BusinessUser businessUser);
}