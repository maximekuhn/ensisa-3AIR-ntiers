using JeBalance.API.Secrete.Securisee.Resources;
using JeBalance.UI.Authentification;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services.SecreteAPI;

public class VIPGetServices : ServiceBase<VIPsAPI, int>
{
    private const string Controller = "VIP";
    private readonly string _baseUrl;

    public VIPGetServices(
        IHttpClientFactory clientFactory,
        IConfiguration configuration,
        AuthenticationStateProvider authStateProvider) : base(clientFactory,
        (CustomAuthenticationStateProvider)authStateProvider)
    {
        _baseUrl = configuration["ApiSecrete:BaseUrl"] ??
                   throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public async Task<VIPsAPI> GetVIPsAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(
            $"{_baseUrl}/{Controller}",
            limit,
            offset);
        var vips = await SendGetAllPaginatedAndCountedRequest(request);
        return vips;
    }
}