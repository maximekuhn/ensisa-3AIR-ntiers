using System.Text;
using System.Text.Json;

namespace JeBalance.UI.Authentification;

public class UserAccountService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly string _interneBaseUrl;
    private readonly string _secreteBaseUrl;
    private const string Controller = "Authenticate";
    
    public UserAccountService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _interneBaseUrl = configuration["ApiInterne:BaseUrl"] ??
                          throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
        _secreteBaseUrl = configuration["ApiSecrete:BaseUrl"] ??
                          throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public async Task<UserSession?> LoginInterneAsync(string email, string password)
    {
        var request = MakeRequest($"{_interneBaseUrl}/{Controller}/login", email, password);
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode) return null;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var session = await JsonSerializer.DeserializeAsync<UserSession>(responseStream);
        return session;
    }
    
    public async Task<UserSession?> LoginSecreteAsync(string email, string password)
    {
        var request = MakeRequest($"{_secreteBaseUrl}/{Controller}/login", email, password);
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode) return null;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var session = await JsonSerializer.DeserializeAsync<UserSession>(responseStream);
        return session;
    }

    private HttpRequestMessage MakeRequest(string url, string email, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        var httpContent = new StringContent(
            JsonSerializer.Serialize(new { email, password }),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        return request;
    }
}