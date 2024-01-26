using JeBalance.API.Interne.Securisee.Resources;

namespace JeBalance.UI.Data.Services.InterneAPI;

public class ReponseServices : ServiceBase<ReponseCreateAPI, int>
{
    private const string Controller = "Reponse";
    private readonly string _baseUrl;

    public ReponseServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory, null)
    {
        _baseUrl = configuration["ApiInterne:BaseUrl"] ??
                   throw new InvalidOperationException("API Base URL not configured");
    }

    public async Task<int> AddReponseAsync(Guid denonciationId, ReponseCreateAPI reponse)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create?denonciationId={denonciationId}", reponse);
        var id = await SendAddRequest(request);
        return id;
    }
}