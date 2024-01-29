using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.UI.Authentification;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services.InterneAPI;

public class DenonciationServices : ServiceBase<DenonciationGetAPI, Guid>
{
    private const string Controller = "Denonciation";
    private readonly string _baseUrl;

    public DenonciationServices(IHttpClientFactory clientFactory,
        IConfiguration configuration,
        AuthenticationStateProvider authStateProvider) : base(clientFactory, (CustomAuthenticationStateProvider)authStateProvider)
    {
        _baseUrl = configuration["ApiInterne:BaseUrl"] ??
                   throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
    }

    public async Task<DenonciationGetAPI[]> GetDenonciationNonTraiteeAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(
            $"{_baseUrl}/{Controller}/denonciationsNonTraitees",
            limit,
            offset);
        var denonciations = await SendGetAllPaginatedRequest(request);
        return denonciations;
    }
}