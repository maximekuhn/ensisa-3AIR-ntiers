using System.Text;
using System.Text.Json;

namespace JeBalance.UI.Authentification;

public class UserAccountService<TResponse, TSourceData>
{
    private readonly IHttpClientFactory _clientFactory;

    public UserAccountService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    protected HttpRequestMessage MakeRequest(string url, TSourceData data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");
        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        return request;
    }
    
    protected async Task<TResponse> SendRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var res = await JsonSerializer.DeserializeAsync<TResponse>(responseStream);
        return res;
    }
    
}