using AdvanceCore.Domain.Entities;

namespace AdvanceCore.Application.Persistence;

public interface IUserProfileRepository
{
    ApplicationUser? GetById(string userId);
}
