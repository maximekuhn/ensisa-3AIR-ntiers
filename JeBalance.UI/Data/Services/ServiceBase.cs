using System.Text;
using System.Text.Json;

namespace JeBalance.UI.Data.Services;

public class ServiceBase<TSourceType>
{
    private IHttpClientFactory _clientFactory;

    private const string BaseURL = "https://localhost:7274/api/";
    private string Controller;

    private string Endpoint => $"{BaseURL}{Controller}";

    public ServiceBase(
        IHttpClientFactory clientFactory,
        string controller
    )
    {
        _clientFactory = clientFactory;
        Controller = controller;
    }
    
    public async Task<HttpRequestMessage> MakeGetOneRequest(Guid id)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{Endpoint}/{id}");

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "ParkNGo");

        return request;
    }

    public async Task<HttpRequestMessage> MakeAddRequest(TSourceType data)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{Endpoint}"
            );
        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json"
            );
        request.Content = httpContent;
        
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "ParkNGo");
        
        return request;
    }
    
    public async Task<TSourceType> SendGetOneRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default(TSourceType);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<TSourceType>(responseStream);
        return data;
    }
    
    public async Task<Guid?> SendAddRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return null;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<Guid>(responseStream);
        return id;
    }
    
}