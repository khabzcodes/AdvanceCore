using Microsoft.AspNetCore.Identity;

namespace AdvanceCore.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser(
        string firstName,
        string lastName,
        string email,
        DateTime createdAtUtc)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = email;
        UserName = UserName;
        CreatedAtUtc = createdAtUtc;
    }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; }

    public static ApplicationUser Create(
        string firstName,
        string lastName,
        string email,
        DateTime createdAtUtc)
    {
        ApplicationUser user = new ApplicationUser(
            firstName,
            lastName,
            email,
            createdAtUtc);

        return user;
    }
}