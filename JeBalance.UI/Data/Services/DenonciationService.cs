using JeBalance.API.Publique.Resources;

namespace JeBalance.UI.Data.Services;

public class DenonciationService : ServiceBase<DenonciationAPI, Guid>
{
    private readonly string _baseUrl;
    private const string Controller = "Denonciation";

    public DenonciationService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _baseUrl = configuration["ApiPublique:BaseUrl"] ?? throw new InvalidOperationException("API Base URL not configured");
    }

    public async Task<Guid?> AddDenonciationAsync(DenonciationAPI denonciation)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create", denonciation);
        var id = await SendAddRequest(request);
        return id;
    }
}