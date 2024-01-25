using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services.PubliqueAPI;

public class DenonciationService : ServiceBase<DenonciationAPI, Guid>
{
    private const string Controller = "Denonciation";
    private readonly string _baseUrl;

    public DenonciationService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory,
        null)
    {
        _baseUrl = configuration["ApiPublique:BaseUrl"] ??
                   throw new InvalidOperationException("API Base URL not configured");
    }

    public async Task<Guid?> AddDenonciationAsync(DenonciationAPI denonciation)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create", denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}