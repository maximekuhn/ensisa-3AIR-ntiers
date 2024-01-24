using System.Security.Claims;
using System.Text.Json.Serialization;

namespace JeBalance.UI.Authentification;

public class UserSession
{
    [JsonPropertyName("username")] public string UserName { get; set; }

    [JsonPropertyName("role")] public string Role { get; set; }

    [JsonPropertyName("driverid")] public int DriverId { get; set; }

    [JsonPropertyName("token")] public string Token { get; set; }

    public ClaimsPrincipal ToClaimsPrincipal(string? authenticationType = "CustomAuth")
    {
        return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new(ClaimTypes.Name, UserName),
            new(ClaimTypes.Role, Role),
            new(ClaimTypes.UserData, DriverId.ToString())
        }, authenticationType));
    }
}