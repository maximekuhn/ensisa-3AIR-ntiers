using JeBalance.API.Secrete.Securisee.Resources;

namespace JeBalance.UI.Data.Services.SecreteAPI;

public class VIPGetServices : ServiceBase<VIPGetAPI, int>
{
    private const string Controller = "VIP";
    private readonly string _baseUrl;

    public VIPGetServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory, null)
    {
        _baseUrl = configuration["ApiSecrete:BaseUrl"] ??
                   throw new InvalidOperationException("ApiSecrete:BaseUrl not configured");
    }

    public async Task<VIPGetAPI[]> GetVIPsAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(
            $"{_baseUrl}/{Controller}",
            limit,
            offset);
        var vips = await SendGetAllPaginatedRequest(request);
        return vips;
    }
}