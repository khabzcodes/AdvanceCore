using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AdvanceCore.UI.Models.ViewModels.Authentication;

public class RegisterViewModel
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [EmailAddress]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("companyName")]
    public string CompanyName { get; set; } = string.Empty;

    [JsonPropertyName("companyEmail")]
    public string CompanyEmail { get; set; } = string.Empty;
}
