using JeBalance.API.Secrete.Securisee.Resources;
using JeBalance.UI.Authentification;

namespace JeBalance.UI.Data.Services.SecreteAPI;

public class VIPServices : ServiceBase<VIPAPI, int>
{
    private readonly string _baseUrl;
    private const string Controller = "VIP";
    
    public VIPServices(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory, null)
    {
        _baseUrl = configuration["ApiSecrete:BaseUrl"] ?? throw new InvalidOperationException("API Base URL not configured");
    }
    
    public async Task<int> AddVIPAsync(VIPAPI vip)
    {
        var request = await MakeAddRequest($"{_baseUrl}/{Controller}/create", vip);
        var id = await SendAddRequest(request);
        return id;
    }
    
    public async Task<bool> DeleteVIPAsync(int vipId)
    {
        var request = await MakeDeleteRequest($"{_baseUrl}/{Controller}/{vipId}");
        await SendDeleteRequest(request);
        return true;
    }
    
    public async Task<VIPAPI[]> GetVIPsAsync(int limit, int offset)
    {
        var request = await MakePaginatedGetAllRequest(
            $"{_baseUrl}/{Controller}/", 
            limit,
            offset);
        var vips = await SendGetAllPaginatedRequest(request);
        return vips;
    }
}