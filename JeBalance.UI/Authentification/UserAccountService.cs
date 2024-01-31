using System.Text;
using System.Text.Json;
using JeBalance.UI.Data.Services.Error;

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

    protected async Task<RequestResult<TResponse?>> SendRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();
            var errorMessage = JsonSerializer.Deserialize<RequestError>(message);
            return new RequestResult<TResponse?>(errorMessage?.Message ?? "Une erreur est survenue");
        }

        var res = await JsonSerializer.DeserializeAsync<TResponse>(responseStream);
        return new RequestResult<TResponse?>(res);
    }
}