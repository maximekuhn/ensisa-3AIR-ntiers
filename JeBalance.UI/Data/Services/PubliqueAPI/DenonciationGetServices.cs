using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services.PubliqueAPI;

public class DenonciationGetServices : ServiceBase<DenonciationGetAPI, Guid>
{
    private const string Controller = "Denonciation";
    private readonly string _baseUrl;

    public DenonciationGetServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory,
        null)
    {
        _baseUrl = configuration["ApiPublique:BaseUrl"] ??
                   throw new InvalidOperationException("API Base URL not configured");
    }

    public async Task<DenonciationGetAPI> GetDenonciationAsync(Guid id)
    {
        var request = await MakeGetOneRequest($"{_baseUrl}/{Controller}?denonciationId={id}");
        var denonciation = await SendGetOneRequest(request);
        return denonciation;
    }
}