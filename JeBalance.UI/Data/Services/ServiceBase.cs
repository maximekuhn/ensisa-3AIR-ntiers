using System.Text;
using System.Text.Json;
using JeBalance.Domain.Model;

namespace JeBalance.UI.Data.Services;

public class ServiceBase<TSourceType, TId>
{
    private readonly IHttpClientFactory _clientFactory;
    
    public ServiceBase(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    
    public async Task<HttpRequestMessage> MakeGetOneRequest(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        return request;
    }

    public async Task<HttpRequestMessage> MakeAddRequest(string url, TSourceType data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json"
        );
        request.Content = httpContent;

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        return request;
    }

    public async Task<TSourceType> SendGetOneRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<TSourceType>(responseStream);
        return data;
    }

    public async Task<TId?> SendAddRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<TId>(responseStream);
        return id;
    }
}