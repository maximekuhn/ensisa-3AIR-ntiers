using JeBalance.API.Interne.Securisee.Resources;

namespace JeBalance.UI.Data.Services.InterneAPI;

public class DenonciationServices : ServiceBase<DenonciationGetAPI, Guid>
{
    private const string Controller = "Denonciation";
    private readonly string _baseUrl;

    public DenonciationServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory,
        null)
    {
        _baseUrl = configuration["ApiInterne:BaseUrl"] ??
                   throw new InvalidOperationException("API Base URL not configured");
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