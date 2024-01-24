using System.Security.Claims;
using System.Text.Json.Serialization;

namespace JeBalance.UI.Authentification;
public class UserSession
{
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }

    [JsonPropertyName("driverid")]
    public int DriverId { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }

    public ClaimsPrincipal ToClaimsPrincipal(string? authenticationType = "CustomAuth")
    {
        return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, UserName),
            new Claim(ClaimTypes.Role, Role),
            new Claim(ClaimTypes.UserData, DriverId.ToString())
        }, authenticationType));
    }
}