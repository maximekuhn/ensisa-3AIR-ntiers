using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JeBalance.API.Securite.Shared.Model;

public class LoginModel
{
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}