namespace JeBalance.API.Securite.Shared;

public class AuthenticationResult
{
    public bool Success { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}