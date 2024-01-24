using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services;

public class DenonciationGetService : ServiceBase<DenonciationGetAPI, Guid>
{
    private readonly string _baseUrl;
    private const string Controller = "Denonciation";

    public DenonciationGetService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _baseUrl = configuration["ApiPublique:BaseUrl"] ?? throw new InvalidOperationException("API Base URL not configured");
    }

    public async Task<DenonciationGetAPI> GetDenonciationAsync(Guid id)
    {
        var request = await MakeGetOneRequest($"{_baseUrl}/{Controller}?denonciationId={id}");
        var denonciation = await SendGetOneRequest(request);
        return denonciation;
    }
    
}