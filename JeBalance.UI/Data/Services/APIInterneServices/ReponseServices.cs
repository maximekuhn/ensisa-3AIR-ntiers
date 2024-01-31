using JeBalance.API.Interne.Securisee.Resources;
using JeBalance.UI.Authentification;
using JeBalance.UI.Data.Services.Error;
using Microsoft.AspNetCore.Components.Authorization;

namespace JeBalance.UI.Data.Services.InterneAPI;

public class ReponseServices : ServiceBase<ReponseCreateAPI, int>
{
    private const string Controller = "Reponse";
    private readonly string _baseUrl;

    public ReponseServices(IHttpClientFactory clientFactory,
        IConfiguration configuration,
        AuthenticationStateProvider authStateProvider) : base(clientFactory,
        (CustomAuthenticationStateProvider)authStateProvider)
    {
        _baseUrl = configuration["ApiInterne:BaseUrl"] ??
                   throw new InvalidOperationException("ApiInterne:BaseUrl not configured");
    }

    public async Task<RequestResult<int>> AddReponseAsync(Guid denonciationId, ReponseCreateAPI reponse)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create?denonciationId={denonciationId}", reponse);
        var id = await SendAddRequest(request);
        return id;
    }
}