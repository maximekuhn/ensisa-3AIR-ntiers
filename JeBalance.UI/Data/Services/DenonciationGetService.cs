using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services;

public class DenonciationGetService : ServiceBase<DenonciationGetAPI, Guid>
{
    private const string BaseUrl = "https://localhost:7274/api/";
    private const string Controller = "Denonciation";

    public DenonciationGetService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<DenonciationGetAPI> GetDenonciationAsync(Guid id)
    {
        var request = await MakeGetOneRequest($"{BaseUrl}{Controller}?denonciationId={id}");
        var denonciation = await SendGetOneRequest(request);
        return denonciation;
    }
}