using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using JeBalance.UI.Authentification;
using Microsoft.AspNetCore.WebUtilities;

namespace JeBalance.UI.Data.Services;

public class ServiceBase<TSourceType, TId>
{
    private readonly CustomAuthenticationStateProvider? _casp;
    private readonly IHttpClientFactory _clientFactory;

    public ServiceBase(IHttpClientFactory clientFactory, CustomAuthenticationStateProvider? casp)
    {
        _clientFactory = clientFactory;
        _casp = casp;
    }

    public async Task<HttpRequestMessage> MakePaginatedGetAllRequest(
        string url,
        int limit,
        int offset)
    {
        var param = new Dictionary<string, string>
        {
            { "limit", limit.ToString() },
            { "offset", offset.ToString() }
        };

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            new Uri(QueryHelpers.AddQueryString(url, param)));

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        if (_casp == null) return request;
        var token = await _casp.GetJWT();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeGetOneRequest(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        if (_casp == null) return request;
        var token = await _casp.GetJWT();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

        if (_casp == null) return request;
        var token = await _casp.GetJWT();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeUpdateRequest(string url, TSourceType data)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Put, url);

        var httpContent = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8,
            "application/json");
        request.Content = httpContent;

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        if (_casp == null) return request;
        var token = await _casp.GetJWT();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<HttpRequestMessage> MakeDeleteRequest(string url)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Delete, url);

        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "JeBalance");

        if (_casp == null) return request;
        var token = await _casp.GetJWT();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    public async Task<TSourceType[]> SendGetAllPaginatedRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var data = await JsonSerializer.DeserializeAsync<TSourceType[]>(responseStream);
        return data;
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

    public async Task<TId> SendAddRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<TId>(responseStream);
        return id;
    }

    public async Task<TId> SendUpdateRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return default;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var id = await JsonSerializer.DeserializeAsync<TId>(responseStream);
        return id;
    }

    public async Task<bool> SendDeleteRequest(HttpRequestMessage request)
    {
        var client = _clientFactory.CreateClient();

        var response = await client.SendAsync(request);
        if (!response.IsSuccessStatusCode) return false;

        using var responseStream = await response.Content.ReadAsStreamAsync();
        var result = await JsonSerializer.DeserializeAsync<bool>(responseStream);
        return result;
    }
}