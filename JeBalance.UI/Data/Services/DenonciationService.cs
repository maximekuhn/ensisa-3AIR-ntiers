using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services;

public class DenonciationService : ServiceBase<DenonciationAPI, Guid>
{
    private const string BaseUrl = "https://localhost:7274/api/";
    private const string Controller = "Denonciation";

    public DenonciationService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<Guid?> AddDenonciationAsync(DenonciationAPI denonciation)
    {
        var request = await MakeAddRequest($"{BaseUrl}{Controller}/create", denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}