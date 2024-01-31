using JeBalance.API.Publique.Resources;
using JeBalance.UI.Data.Services.Error;

namespace JeBalance.UI.Data.Services.PubliqueAPI;

public class DenonciationServices : ServiceBase<DenonciationAPI, Guid>
{
    private const string Controller = "Denonciation";
    private readonly string _baseUrl;

    public DenonciationServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory,
        null)
    {
        _baseUrl = configuration["ApiPublique:BaseUrl"] ??
                   throw new InvalidOperationException("APIPublique:BaseUrl not configured");
    }

    public async Task<RequestResult<Guid>> AddDenonciationAsync(DenonciationAPI denonciation)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create", denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}