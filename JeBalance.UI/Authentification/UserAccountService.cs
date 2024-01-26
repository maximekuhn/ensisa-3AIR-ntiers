using System.Text;
using System.Text.Json;

namespace JeBalance.UI.Authentification;

public class UserAccountService
{
    private readonly string _baseUrl;
    private readonly IHttpClientFactory _clientFactory;


    public UserAccountService(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        // Todo : Add base url in app setting and change here
        _baseUrl = "";
    }

    public async Task<UserSession?> LoginAsync(string username, string password)
    {
        var request = MakeRequest(username, password);
        var client = _clientFactory.CreateClient();
        var response = await client.SendAsync(request);

        if (!response.IsSuccessStatusCode) return null;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var session = await JsonSerializer.DeserializeAsync<UserSession>(responseStream);
        return session;
    }

    private HttpRequestMessage MakeRequest(string username, string password)
    {
        // TODO : Change this function and use ServiceBase

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{_baseUrl}");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        var httpContent = new StringContent(
            JsonSerializer.Serialize(new { username, password }),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        return request;
    }
}